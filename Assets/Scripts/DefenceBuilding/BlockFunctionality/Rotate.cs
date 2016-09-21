using UnityEngine;
using System.Collections;

public class Rotate : PowerNode
{
    [SerializeField]
    float turnSpeed;
    float turnDir;
    bool canRot;
    bool[] dir = new bool[6] { true, true, true, true, true, true };

    protected override void Start()
    {
        for (int i = 0; i < 6; i++)
        {
            if (i == 1 || i == 3)
            {
                GetComponent<BoxUVs>().SetSide(i, BoxUVs.Side.ROTANTCLOCKL);
            }

            else
            {
                GetComponent<BoxUVs>().SetSide(i, BoxUVs.Side.ROTANTCLOCKU);
            }
        }

        turnDir = 1;
    }

    protected override void Update()
    {
        base.Update();

        if (et.GetCanDo() && canRot)
        {
            RotateF();
        }

        else if (!et.GetCanDo() && !canRot)
        {
            canRot = true;
        }
    }

    void RotateF()
    {
        SetFace();

        for (int i = 0; i < face.Length; i++)
        {
            if (isActive[i] && isPowered)
            {
                if (face[i].transform.parent == null && face[i] != null && face[i].GetComponent<Static>() == null)
                {
                    if (face[i].IsMaster(i) && face[i].GetCanStart())
                    {
                        turnDir = dir[i] == true ? turnDir * 1 : turnDir * -1;

                        face[i].transform.RotateAround(transform.position, (face[i].transform.position - transform.position).normalized, turnSpeed * turnDir);
                        if (face[i].transform.rotation.eulerAngles == Vector3.zero)
                        {
                            Debug.Log("Yeah");
                            canRot = false;
                        }
                    }
                }
            }
        }
    }

    public void ChangeDir()
    {
        if (true)
        {

        }

        else
        {

        }
    }
}