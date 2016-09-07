using UnityEngine;
using System.Collections;

public class EventTimer : MonoBehaviour
{
    bool canDo;
    bool toggle;

    public bool GetCanDo() { return canDo; }
    public bool GetToggle() { return toggle; }

    public void SetToggle(bool _toggle) { toggle = _toggle; }

    void Start()
    {
        canDo = true;
        toggle = true;
        InvokeRepeating("ChangeState", 0.0f, 1.5f);
    }

    void ChangeState()
    {
        canDo = canDo == false ? true : false;
        toggle = true;
    }
}
