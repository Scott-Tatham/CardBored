using UnityEngine;
using System.Collections;

public class Signal : BaseBlock
{
    public enum BlockMode
    {
        SWITCH,
        BUTTON,
        AND,
        OR,
    }

    bool isOn;
    BlockMode bm;

    protected override void Awake()
    {
        base.Awake();

        bm = BlockMode.SWITCH;
    }

    protected override void Update()
    {
        base.Update();

        SignalF();
    }

    void SignalF()
    {
        if (Input.GetKeyDown(KeyCode.Semicolon))
        {
            SetFace();
            isOn = isOn == false ? true : false;

            switch (bm)
            {
                case BlockMode.SWITCH:
                    for (int i = 0; i < face.Length; i++)
                    {
                        if (face[i] != null && face[i].GetComponent<PowerNode>() != null)
                        {
                            face[i].GetComponent<PowerNode>().AlterState(isOn);
                        }
                    }

                    break;

                case BlockMode.BUTTON:
                    break;

                case BlockMode.AND:
                    break;

                case BlockMode.OR:
                    break;
            }
        }
    }
}