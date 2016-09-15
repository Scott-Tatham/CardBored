using UnityEngine;
using System.Collections;

public class Signal : Static
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

    protected override void Start()
    {
        for (int i = 0; i < 6; i++)
        {
            GetComponent<BoxUVs>().SetSide(i, BoxUVs.Side.SIGNAL);
        }
        
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
                    if (isOn)
                    {
                        for (int i = 0; i < face.Length; i++)
                        {
                            if (face[i] != null && face[i].GetComponent<PowerNode>() != null && !face[i].GetComponent<PowerNode>().GetIsPowered())
                            {
                                face[i].GetComponent<PowerNode>().StateOn();
                            }
                        }
                    }

                    if (!isOn)
                    {
                        for (int i = 0; i < face.Length; i++)
                        {
                            if (face[i] != null && face[i].GetComponent<PowerNode>() != null && face[i].GetComponent<PowerNode>().GetIsPowered())
                            {
                                face[i].GetComponent<PowerNode>().StateOff();
                            }
                        }
                    }

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