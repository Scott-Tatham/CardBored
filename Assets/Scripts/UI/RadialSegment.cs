using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class RadialSegment : MonoBehaviour, IPointerEnterHandler//, IPointerExitHandler
{
    public void ActivateChild()
    {
        // Needs to know which object. Event sytem data is required.
        transform.GetComponentInChildren<Transform>().gameObject.SetActive(true);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject.tag == "Segment")
        {
            //switch
        }
    }
}