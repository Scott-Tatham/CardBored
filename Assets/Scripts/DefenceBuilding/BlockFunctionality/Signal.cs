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

<<<<<<< HEAD
    bool isOn;
    BlockMode bm;
=======
    private bool isOn;
    private BlockMode bm;
>>>>>>> parent of 7df8639... More Of The Same Defence Building Stuff

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
<<<<<<< HEAD
            SetFace();
=======
            isOn = isOn == false ? true : false;
>>>>>>> parent of 7df8639... More Of The Same Defence Building Stuff

            switch (bm)
            {
                case BlockMode.SWITCH:
<<<<<<< HEAD
                    isOn = isOn == false ? true : false;

                    for (int i = 0; i < face.Length; i++)
                    {
                        if (face[0] != null && face[0].GetComponent<PowerNode>() != null)
                        {
                            face[0].GetComponent<PowerNode>().State(isOn);
                        }
                    }
=======
                    if (bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.forward.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.forward.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.forward.z)] != null && bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.forward.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.forward.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.forward.z)].GetComponent<PowerNode>() != null)
                    {
                        BaseBlock b = bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.forward.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.forward.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.forward.z)];
>>>>>>> parent of 7df8639... More Of The Same Defence Building Stuff

                        b.GetComponent<PowerNode>().State(isOn);
                    }

<<<<<<< HEAD
                case BlockMode.BUTTON:
                    break;

                case BlockMode.AND:

                    break;

=======
                    if (bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.back.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.back.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.back.z)] != null && bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.back.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.back.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.back.z)].GetComponent<PowerNode>() != null)
                    {
                        BaseBlock b = bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.back.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.back.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.back.z)];

                        b.GetComponent<PowerNode>().State(isOn);
                    }

                    if (bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.forward.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.forward.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.forward.z)] != null && bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.forward.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.forward.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.forward.z)].GetComponent<PowerNode>() != null)
                    {
                        BaseBlock b = bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.forward.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.forward.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.forward.z)];

                        b.GetComponent<PowerNode>().State(isOn);
                    }

                    if (bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.forward.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.forward.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.forward.z)] != null && bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.forward.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.forward.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.forward.z)].GetComponent<PowerNode>() != null)
                    {
                        BaseBlock b = bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.forward.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.forward.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.forward.z)];

                        b.GetComponent<PowerNode>().State(isOn);
                    }

                    if (bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.forward.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.forward.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.forward.z)] != null && bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.forward.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.forward.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.forward.z)].GetComponent<PowerNode>() != null)
                    {
                        BaseBlock b = bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.forward.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.forward.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.forward.z)];

                        b.GetComponent<PowerNode>().State(isOn);
                    }

                    if (bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.forward.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.forward.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.forward.z)] != null && bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.forward.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.forward.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.forward.z)].GetComponent<PowerNode>() != null)
                    {
                        BaseBlock b = bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.forward.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.forward.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.forward.z)];

                        b.GetComponent<PowerNode>().State(isOn);
                    }

                    break;

                case BlockMode.BUTTON:
                    break;

                case BlockMode.AND:
                    break;

>>>>>>> parent of 7df8639... More Of The Same Defence Building Stuff
                case BlockMode.OR:
                    break;
            }
        }
    }
}