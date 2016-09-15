using UnityEngine;
using System.Collections;

public class BoundingBox : MonoBehaviour
{
    [SerializeField]
    Vector3 bounds;
    [SerializeField]
    GameObject boundUI;
    [SerializeField]
    GameObject baseBlock;
    GameObject buildingPlatform;
    BaseBlock[,,] blocks;

    public Vector3 GetBounds() { return bounds; }
    public BaseBlock[,,] GetBlocks() { return blocks; }

    void Awake()
    {
        blocks = new BaseBlock[Mathf.RoundToInt(bounds.x), Mathf.RoundToInt(bounds.y), Mathf.RoundToInt(bounds.z)];
        GetComponent<BoxCollider>().size = new Vector3(bounds.x, bounds.y, bounds.z);
        GetComponent<BoxCollider>().center = new Vector3((bounds.x / 2) - 0.5f, bounds.y / 2, (bounds.z / 2) - 0.5f);
    }

    void Start()
    {
        for (int x = 0; x < bounds.x; x++)
        {
            for (int z = 0; z < bounds.z; z++)
            {
                GameObject BaseBlock = Instantiate(baseBlock, new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z), Quaternion.identity) as GameObject;
                BaseBlock.hideFlags = HideFlags.HideInHierarchy;
            }
        }

        GameObject BuildZoneUI = Instantiate(boundUI, new Vector3((bounds.x / 2) - 0.5f + transform.position.x, (transform.position.y + bounds.y / 2) + 0.01f, (bounds.z / 2) - 0.5f + transform.position.z), Quaternion.identity) as GameObject;
        BuildZoneUI.transform.localScale = new Vector3 (bounds.x + 0.01f, bounds.y, bounds.z + 0.01f);
    }

    // May possibly become the mega checker.
    public bool CheckBlock(Vector3 _pos)
    {
        if (blocks[Mathf.RoundToInt(_pos.x), Mathf.RoundToInt(_pos.y), Mathf.RoundToInt(_pos.z)] == null)
        {
            return true;
        }

        return false;
    }

    public void AddBlock(BaseBlock _bb)
    {
        blocks[Mathf.RoundToInt(_bb.GetBZSpace().GetBZSpace().x), Mathf.RoundToInt(_bb.GetBZSpace().GetBZSpace().y), Mathf.RoundToInt(_bb.GetBZSpace().GetBZSpace().z)] = _bb;
    }

    public void RemoveBlock(BaseBlock _bb)
    {
        blocks[Mathf.RoundToInt(_bb.GetBZSpace().GetBZSpace().x), Mathf.RoundToInt(_bb.GetBZSpace().GetBZSpace().y), Mathf.RoundToInt(_bb.GetBZSpace().GetBZSpace().z)] = null;
    }

    public void MoveBlock(BaseBlock _bb, Vector3 _dir)
    {
        blocks[Mathf.RoundToInt(_bb.GetBZSpace().GetBZSpace().x), Mathf.RoundToInt(_bb.GetBZSpace().GetBZSpace().y), Mathf.RoundToInt(_bb.GetBZSpace().GetBZSpace().z)] = _bb;
        blocks[Mathf.RoundToInt(_bb.GetBZSpace().GetBZSpace().x - _dir.x), Mathf.RoundToInt(_bb.GetBZSpace().GetBZSpace().y - _dir.y), Mathf.RoundToInt(_bb.GetBZSpace().GetBZSpace().z - _dir.z)] = null;
    }
}