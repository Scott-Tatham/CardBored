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

    private bool isOn;
    private BlockMode bm;

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
            isOn = isOn == false ? true : false;

            switch (bm)
            {
                case BlockMode.SWITCH:
                    if (bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.forward.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.forward.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.forward.z)] != null && bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.forward.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.forward.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.forward.z)].GetComponent<PowerNode>() != null)
                    {
                        BaseBlock b = bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.forward.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.forward.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.forward.z)];

                        b.GetComponent<PowerNode>().State(isOn);
                    }

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

                case BlockMode.OR:
                    break;
            }
        }
    }
}