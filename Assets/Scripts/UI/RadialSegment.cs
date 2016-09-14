using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class RadialSegment : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    bool isOn;

    public void OnPointerEnter(PointerEventData _ped)
    {
        isOn = true;
        Debug.Log("Over");
    }

    public void OnPointerExit(PointerEventData _ped)
    {
        isOn = false;
        Debug.Log("Off");
    }

    void Update()
    {

    }

    void Over()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            isOn = true;
            Debug.Log("Over");
        }

        else
        {
            isOn = false;
            Debug.Log("Off");
        }
    }
}
