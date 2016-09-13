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
    float buttTime;
    BlockMode bm;

    public bool GetIsOn() { return isOn; }

    protected override void Awake()
    {
        base.Awake();

        buttTime = 1.0f;
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
                    break;

                case BlockMode.BUTTON:
                    StartCoroutine(ButtTime());
                    break;

                case BlockMode.AND:
                    /*foreach (BaseBlock f in face)
                    {
                        if (f != null && f.GetComponent<PowerNode>() != null)
                        {
                            if (f.GetComponent<PowerNode>().GetIsPowered())
                            {
                                powerReq++;
                            }
                        }
                    }

                    if (powerReq == inputFaces)
                    {
                        outputFaces.SetIsPowered()
                    }*/

                    break;

                case BlockMode.OR:
                    break;
            }
        }
    }

    IEnumerator ButtTime()
    {
        yield return new WaitForSeconds(buttTime);
        isOn = isOn == false ? true : false;
    }
}