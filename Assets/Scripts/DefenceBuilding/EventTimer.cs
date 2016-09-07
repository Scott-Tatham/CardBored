using UnityEngine;
using System.Collections;

public class EventTimer : MonoBehaviour
{
    private bool canDo;

    public bool GetCanDo() { return canDo; }
    
    void Start()
    {
        InvokeRepeating("ChangeState", 0.0f, 1.5f);
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
