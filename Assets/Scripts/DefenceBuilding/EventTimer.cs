using UnityEngine;
using System.Collections;

public class EventTimer : MonoBehaviour
{
    bool canDo;
    float time;

    public bool GetCanDo() { return canDo; }
    
    void Start()
    {
        time = 1.1f;
        InvokeRepeating("ChangeState", 0.0f, time);
    }

    void ChangeState()
    {
        if (canDo)
        {
            canDo = false;
            time = 0.1f;
        }

        else
        {
            canDo = true;
            time = 1.1f;
        }
    }
}
