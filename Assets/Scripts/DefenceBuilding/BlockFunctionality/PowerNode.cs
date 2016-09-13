using UnityEngine;
using System.Collections;

public class PowerNode : BaseBlock
{
    bool canCheck;
    protected bool isPowered;
    BaseBlock source;
    BaseBlock sourceChild;

    public bool GetIsPowered() { return isPowered; }
    public BaseBlock GetSource() { return source; }

    public void SetSourceChild()
    {
        //if (sourceChild != null)
        {
            //sourceChild.GetComponent<Transmit>().SetSourceChild();
        }

        source = null;
        sourceChild = null;
    }

    protected override void Start()
    {
        base.Start();

        canCheck = true;
    }

    protected override void Update()
    {
        base.Update();

        if (!et.GetCanDo() && canCheck)
        {
            if (source == null || (source.GetComponent<Signal>() != null && !source.GetComponent<Signal>().GetIsOn()))
            {
                if (sourceChild != null)
                {
                    sourceChild.GetComponent<Transmit>().SetSourceChild();
                }

                source = null;
                sourceChild = null;
                isPowered = false;
                State();
            }
        }

        if (et.GetCanDo() && !canCheck)
        {
            canCheck = true;
        }
    }

    public void State()
    {
        SetFace();

        for (int i = 0; i < face.Length; i++)
        {
            if (face[i] != null)
            {
                if (face[i].GetComponent<Transmit>() != null && face[i].GetComponent<Transmit>().GetIsPowered())
                {
                    source = face[i].GetComponent<Transmit>().GetSource();
                    sourceChild = face[i];
                    isPowered = true;

                    break;
                }

                else if (face[i].GetComponent<Signal>() != null && face[i].GetComponent<Signal>().GetIsOn())
                {
                    source = face[i];
                    isPowered = true;

                    break;
                }
            }
        }

        canCheck = false;
    }
}