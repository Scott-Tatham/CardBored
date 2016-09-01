using UnityEngine;
using System.Collections;

public class EventTimer : MonoBehaviour
{
    private bool canDo;

    public bool GetCanDo() { return canDo; }

    // Need some way of not moving blocks placed halfway through cycle.
    void Start()
    {
        InvokeRepeating("ChangeState", 0.0f, 2.0f);
    }

    void ChangeState()
    {
        if (canDo)
        {
            canDo = false;
        }

        else
        {
            canDo = true;
        }
    }
}
