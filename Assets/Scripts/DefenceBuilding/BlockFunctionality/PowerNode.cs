using UnityEngine;
using System.Collections;

public class PowerNode : BaseBlock
{
    protected bool isPowered;
    protected bool external;
    protected bool[] stream = new bool[6] { true, true, true, true, true, true };
    
    public bool GetIsPowered() { return isPowered; }

    void Start()
    {
        isPowered = false;
    }

    protected override void Update()
    {
        base.Update();

        State();
    }

    public void State()
    {
        SetFace();

        for (int i = 0; i < face.Length; i++)
        {
            if (face[i] != null && face[i].GetComponent<Transmit>() != null)
            {
                if (face[i].GetComponent<Transmit>().GetIsPowered())
                {
                    isPowered = true;
                    break;
                }

                if (i == face.Length - 1 && isPowered == false && external == false)
                {
                    isPowered = false;
                }
            }
        }
    }

    public void AlterState(bool _state)
    {
        isPowered = _state == true ? true : false;
        external = _state == true ? true : false;
    }
}