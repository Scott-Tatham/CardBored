using UnityEngine;
using System.Collections;

public class BoundingBox : MonoBehaviour
{
    private Bounds buildZone;

    public Bounds GetBuildZone() { return buildZone; }

    void Awake()
    {
        buildZone = new Bounds(transform.position, new Vector3(30, 20, 30));
    }
}