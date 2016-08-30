using UnityEngine;
using System.Collections;

public class BoundingBox : MonoBehaviour
{
    [SerializeField]
    private Vector3 bounds;
    [SerializeField]
    private GameObject boundUI;
    [SerializeField]
    private GameObject baseBlock;
    private GameObject buildingPlatform;
    private BaseBlock[,,] blocks;
    private Vector3 zeroPoint;

    void Awake()
    {
        blocks = new BaseBlock[Mathf.RoundToInt(bounds.x), Mathf.RoundToInt(bounds.y), Mathf.RoundToInt(bounds.z)];
        GetComponent<BoxCollider>().size = new Vector3(bounds.x, bounds.y, bounds.z);
        GetComponent<BoxCollider>().center = new Vector3(transform.position.x, (bounds.y / 2) + 0.5f, transform.position.z);
    }

    void Start()
    {
        for (int x = 0; x < bounds.x; x++)
        {
            for (int z = 0; z < bounds.z; z++)
            {
                GameObject BaseBlock = Instantiate(baseBlock, new Vector3(x - (bounds.x / 2) + 0.5f, transform.position.y + 0.5f, z -  (bounds.z / 2) + 0.5f), Quaternion.identity) as GameObject;
            }
        }

        GameObject BuildZoneUI = Instantiate(boundUI, new Vector3(transform.position.x, (transform.position.y + bounds.y / 2) + 0.51f, transform.position.z), Quaternion.identity) as GameObject;
        BuildZoneUI.transform.localScale = bounds;
        zeroPoint = GetZeroPoint();
    }

    public Vector3 GetZeroPoint()
    {
        int x, y, z;

        if (bounds.x % 2 == 1)
        {
            x = Mathf.RoundToInt((bounds.x / 2) - 0.5f);
        }

        else
        {
            x = Mathf.RoundToInt(bounds.x / 2);
        }

        if (bounds.y % 2 == 1)
        {
            y = Mathf.RoundToInt((bounds.y / 2) - 0.5f);
        }

        else
        {
            y = Mathf.RoundToInt(bounds.y / 2);
        }

        if (bounds.z % 2 == 1)
        {
            z = Mathf.RoundToInt((bounds.z / 2) - 0.5f);
        }

        else
        {
            z = Mathf.RoundToInt((bounds.z / 2) - 2);
        }

        return new Vector3(transform.position.x - x, transform.position.y - y, transform.position.z - z);
    }

    public bool CheckBlock(Vector3 _pos)
    {
        // Fix
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
}