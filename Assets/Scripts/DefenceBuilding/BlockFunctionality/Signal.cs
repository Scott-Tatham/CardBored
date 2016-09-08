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

            switch (bm)
            {
                case BlockMode.SWITCH:
                    isOn = isOn == false ? true : false;

                    for (int i = 0; i < face.Length; i++)
                    {
                        if (face[0] != null && face[0].GetComponent<PowerNode>() != null)
                        {
                            face[0].GetComponent<PowerNode>().State(isOn);
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