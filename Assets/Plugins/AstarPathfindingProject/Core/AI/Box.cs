using UnityEngine;
using System.Collections;
using Pathfinding;

public class Box : MonoBehaviour {

	private Collider col;
	private Bounds prevBounds; 
	void Start () 
	{
		col = GetComponent<Collider>();
		prevBounds = col.bounds;
	}
	 
	void Update () 
	{
	
	}
		
	void OnDestroy () {
	if 	(AstarPath.active != null)
		{
			GraphUpdateObject guo = new GraphUpdateObject(prevBounds);
			AstarPath.active.UpdateGraphs(guo);
		}
	}
}