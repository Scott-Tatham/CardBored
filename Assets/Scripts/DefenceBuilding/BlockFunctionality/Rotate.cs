using UnityEngine;
using System.Collections;

public class Rotate : PowerNode
{
    [SerializeField]
    float turnSpeed;
    bool[] dir = new bool[6] { true, true, true, true, true, true };

    protected override void Update()
    {
        base.Update();

        RotateF();
    }

    void RotateF()
    {
        if (et.GetCanDo())
        {
            SetFace();


            for (int i = 0; i < face.Length; i++)
            {
                if (isActive[i] && isPowered)
                {
                    if (face[i] != null && face[i].GetComponent<PowerNode>() == null && face[i].transform.parent == null && face[i].tag != "StaticBlock")
                    {
                        if (face[i].GetCanStart())
                        {
                            turnSpeed = dir[i] == true ? turnSpeed * 1 : turnSpeed * -1;

                            face[i].transform.RotateAround(transform.position, (face[i].transform.position - transform.position).normalized, turnSpeed);
                        }
                    }
                }
            }
        }
    }
}