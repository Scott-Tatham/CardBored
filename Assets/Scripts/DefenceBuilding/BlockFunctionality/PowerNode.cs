using UnityEngine;
using System.Collections;

public class PowerNode : BaseBlock
{
    protected bool isPowered;

    public bool GetIsPowered() { return isPowered; }

    protected override void Start()
    {
        base.Start();

        SetFace();
        CheckState();
    }

    void CheckState()
    {
        for (int i = 0; i < face.Length; i++)
        {
            if (face[i] != null && face[i].GetComponent<PowerNode>() != null)
            {
                if (face[i].GetComponent<PowerNode>().GetIsPowered())
                {
                    isPowered = true;

                    break;
                }
            }
        }
    }

    public void StateOn()
    {
        isPowered = true;

        for (int i = 0; i < face.Length; i++)
        {
            if (face[i] != null && face[i].GetComponent<PowerNode>() != null && !face[i].GetComponent<PowerNode>().GetIsPowered())
            {
                face[i].GetComponent<PowerNode>().StateOn();
            }
        }
    }

    public void StateOff()
    {
        isPowered = false;

        for (int i = 0; i < face.Length; i++)
        {
            if(face[i] != null && face[i].GetComponent<PowerNode>() != null && face[i].GetComponent<PowerNode>().GetIsPowered())
            {
                face[i].GetComponent<PowerNode>().StateOff();
            }
        }
    }

    public void UpdateFace()
    {
        SetFace();
        CheckState();
    }
}