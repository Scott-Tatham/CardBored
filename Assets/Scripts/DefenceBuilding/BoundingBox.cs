using UnityEngine;
using System.Collections;

public class BoundingBox : MonoBehaviour
{
    [SerializeField]
    private Vector3 bounds;
    [SerializeField]
    private GameObject baseBlock;
    private Bounds buildZone;
    private GameObject buildingPlatform;

    public Bounds GetBuildZone() { return buildZone; }

    void Awake()
    {
        buildZone = new Bounds(transform.position, new Vector3(bounds.x, bounds.y, bounds.z));
    }

    void Start()
    {
        for (int x = (0 - Mathf.RoundToInt(bounds.x / 2)); x < bounds.x / 2; x++)
        {
            for (int z = (0 - Mathf.RoundToInt(bounds.z / 2)); z < bounds.z / 2; z++)
            {
                GameObject BaseBlock = Instantiate(baseBlock, new Vector3(x, transform.position.y - 1, z), Quaternion.identity) as GameObject;
            }
        }
    }
}