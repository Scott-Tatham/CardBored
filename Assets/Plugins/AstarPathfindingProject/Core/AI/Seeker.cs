using UnityEngine;
using System.Collections.Generic;
using Pathfinding;

[AddComponentMenu("Pathfinding/Seeker")]
public class Seeker : MonoBehaviour, ISerializationCallbackReceiver {

	public bool drawGizmos = true;

	public bool detailedGizmos;

	/** Path modifier which tweaks the start and end points of a path */
	public StartEndModifier startEndModifier = new StartEndModifier();

	[HideInInspector]
	public int traversableTags = -1;

	[UnityEngine.Serialization.FormerlySerializedAs("traversableTags")]
	[SerializeField]
	[HideInInspector]
	protected TagMask traversableTagsCompatibility = new TagMask(-1, -1);

	[HideInInspector]
	public int[] tagPenalties = new int[32];

	public OnPathDelegate pathCallback;

	/** Called before pathfinding is started */
	public OnPathDelegate preProcessPath;

	/** Called after a path has been calculated, right before modifiers are executed.
	 * Can be anything which only modifies the positions (Vector3[]).
	 */
	public OnPathDelegate postProcessPath;

	/** Used for drawing gizmos */
	[System.NonSerialized]
	List<Vector3> lastCompletedVectorPath;

	/** Used for drawing gizmos */
	[System.NonSerialized]
	List<GraphNode> lastCompletedNodePath;

	/** The current path */
	[System.NonSerialized]
	protected Path path;

	/** Previous path. Used to draw gizmos */
	[System.NonSerialized]
	private Path prevPath;

	/** Cached delegate to avoid allocating one every time a path is started */
	private readonly OnPathDelegate onPathDelegate;

	/** Temporary callback only called for the current path. This value is set by the StartPath functions */
	private OnPathDelegate tmpPathCallback;

	/** The path ID of the last path queried */
	protected uint lastPathID;

	/** Internal list of all modifiers */
	readonly List<IPathModifier> modifiers = new List<IPathModifier>();

	public enum ModifierPass {
		PreProcess,
		// An obsolete item occupied index 1 previously
		PostProcess = 2,
	}

	public Seeker () {
		onPathDelegate = OnPathComplete;
	}

	/** Initializes a few variables */
	void Awake () {
		startEndModifier.Awake(this);
	}
		
	public Path GetCurrentPath () {
		return path;
	}

	public void OnDestroy () {
		ReleaseClaimedPath();
		startEndModifier.OnDestroy(this);
	}
		
	public void ReleaseClaimedPath () {
		if (prevPath != null) {
			prevPath.Release(this, true);
			prevPath = null;
		}
	}

	/** Called by modifiers to register themselves */
	public void RegisterModifier (IPathModifier mod) {
		modifiers.Add(mod);

		// Sort the modifiers based on their specified order
		modifiers.Sort((a, b) => a.Order.CompareTo(b.Order));
	}

	/** Called by modifiers when they are disabled or destroyed */
	public void DeregisterModifier (IPathModifier mod) {
		modifiers.Remove(mod);
	}
		
	public void PostProcess (Path p) {
		RunModifiers(ModifierPass.PostProcess, p);
	}

	/** Runs modifiers on path \a p */
	public void RunModifiers (ModifierPass pass, Path p) {
		// Call delegates if they exist
		if (pass == ModifierPass.PreProcess && preProcessPath != null) {
			preProcessPath(p);
		} else if (pass == ModifierPass.PostProcess && postProcessPath != null) {
			postProcessPath(p);
		}

		// Loop through all modifiers and apply post processing
		for (int i = 0; i < modifiers.Count; i++) {
			// Cast to MonoModifier, i.e modifiers attached as scripts to the game object
			var mMod = modifiers[i] as MonoModifier;

			// Ignore modifiers which are not enabled
			if (mMod != null && !mMod.enabled) continue;

			if (pass == ModifierPass.PreProcess) {
				modifiers[i].PreProcess(p);
			} else if (pass == ModifierPass.PostProcess) {
				modifiers[i].Apply(p);
			}
		}
	}
		
	public bool IsDone () {
		return path == null || path.GetState() >= PathState.Returned;
		Debug.Log ("Stuck");
	}
		
	void OnPathComplete (Path p) {
		OnPathComplete(p, true, true);
	}
		
	void OnPathComplete (Path p, bool runModifiers, bool sendCallbacks) {
		if (p != null && p != path && sendCallbacks) {
			return;
		}

		if (this == null || p == null || p != path)
			return;

		if (!path.error && runModifiers) {
			// This will send the path for post processing to modifiers attached to this Seeker
			RunModifiers(ModifierPass.PostProcess, path);
		}

		if (sendCallbacks) {
			p.Claim(this);

			lastCompletedNodePath = p.path;
			lastCompletedVectorPath = p.vectorPath;

			// This will send the path to the callback (if any) specified when calling StartPath
			if (tmpPathCallback != null) {
				tmpPathCallback(p);
			}

			// This will send the path to any script which has registered to the callback
			if (pathCallback != null) {
				pathCallback(p);
			}

			// Recycle the previous path to reduce the load on the GC
			if (prevPath != null) {
				prevPath.Release(this, true);
			}

			prevPath = p;

			// If not drawing gizmos, then storing prevPath is quite unecessary
			// So clear it and set prevPath to null
			if (!drawGizmos) ReleaseClaimedPath();
		}
	}
		
	public ABPath GetNewPath (Vector3 start, Vector3 end) {
		// Construct a path with start and end points
		return ABPath.Construct(start, end, null);
	}
		
	public Path StartPath (Vector3 start, Vector3 end) {
		return StartPath(start, end, null, -1);
	}

	public Path StartPath (Vector3 start, Vector3 end, OnPathDelegate callback) {
		return StartPath(start, end, callback, -1);
	}
		
	public Path StartPath (Vector3 start, Vector3 end, OnPathDelegate callback, int graphMask) {
		return StartPath(GetNewPath(start, end), callback, graphMask);
	}
		
	public Path StartPath (Path p, OnPathDelegate callback = null, int graphMask = -1) {
		p.enabledTags = traversableTags;
		p.tagPenalties = tagPenalties;
		p.callback += onPathDelegate;
		p.nnConstraint.graphMask = graphMask;

		StartPathInternal(p, callback);
		return path;
	}

	/** Internal method to start a path and mark it as the currently active path */
	void StartPathInternal (Path p, OnPathDelegate callback) {
		// Cancel a previously requested path is it has not been processed yet and also make sure that it has not been recycled and used somewhere else
		if (path != null && path.GetState() <= PathState.Processing && lastPathID == path.pathID) {
			path.Error();
			path.LogError("Canceled path because a new one was requested.\n"+
				"This happens when a new path is requested from the seeker when one was already being calculated.\n" +
				"For example if a unit got a new order, you might request a new path directly instead of waiting for the now" +
				" invalid path to be calculated. Which is probably what you want.\n" +
				"If you are getting this a lot, you might want to consider how you are scheduling path requests.");
			// No callback will be sent for the canceled path
		}

		// Set p as the active path
		path = p;
		tmpPathCallback = callback;

		// Save the path id so we can make sure that if we cancel a path (see above) it should not have been recycled yet.
		lastPathID = path.pathID;

		// Pre process the path
		RunModifiers(ModifierPass.PreProcess, path);

		// Send the request to the pathfinder
		AstarPath.StartPath(path);
	}


	/** Draws gizmos for the Seeker */
	public void OnDrawGizmos () {
		if (lastCompletedNodePath == null || !drawGizmos) {
			return;
		}

		if (detailedGizmos) {
			Gizmos.color = new Color(0.7F, 0.5F, 0.1F, 0.5F);

			if (lastCompletedNodePath != null) {
				for (int i = 0; i < lastCompletedNodePath.Count-1; i++) {
					Gizmos.DrawLine((Vector3)lastCompletedNodePath[i].position, (Vector3)lastCompletedNodePath[i+1].position);
				}
			}
		}

		Gizmos.color = new Color(0, 1F, 0, 1F);

		if (lastCompletedVectorPath != null) {
			for (int i = 0; i < lastCompletedVectorPath.Count-1; i++) {
				Gizmos.DrawLine(lastCompletedVectorPath[i], lastCompletedVectorPath[i+1]);
			}
		}
	}

	/** Handle serialization backwards compatibility */
	void ISerializationCallbackReceiver.OnBeforeSerialize () {
	}

	/** Handle serialization backwards compatibility */
	void ISerializationCallbackReceiver.OnAfterDeserialize () {
		if (traversableTagsCompatibility != null && traversableTagsCompatibility.tagsChange != -1) {
			traversableTags = traversableTagsCompatibility.tagsChange;
			traversableTagsCompatibility = new TagMask(-1, -1);
		}
	}
}
