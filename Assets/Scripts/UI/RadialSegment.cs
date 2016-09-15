using UnityEngine;
using System.Collections;

public class RadialSegment : MonoBehaviour
{
    public void ActivateChild()
    {
        // Needs to know which object. Event sytem data is required.
        transform.GetComponentInChildren<Transform>().gameObject.SetActive(true);
    }
}