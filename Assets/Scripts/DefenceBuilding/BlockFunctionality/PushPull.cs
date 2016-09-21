using UnityEngine;
using System.Collections;

public class PushPull : PowerNode
{
    bool outwards;
    int dir;
    bool[] init = new bool[6] { true, true, true, true, true, true };
    bool[] newRun = new bool[6] { true, true, true, true, true, true };
    Vector3[] target = new Vector3[6];

    protected override void Start()
    {
        base.Start();

        dir = 1;
        outwards = true;
    }

    protected override void Update()
    {
        base.Update();
        CheckHealth();

        if (et.GetCanDo())
        {
            PushPullF();
        }
    }

    void PushPullF()
    {
        if (outwards)
        {
            SetFace();
        }

        else
        {

            SetFace(2);
        }

        for (int i = 0; i < face.Length; i++)
        {
            if (isActive[i] && isPowered)
            {
                if (face[i] != null && face[i].GetComponent<PowerNode>() == null && face[i].transform.parent == null && face[i].GetComponent<Static>() == null)
                {
                    if (face[i].GetCanStart())
                    {
                        if (newRun[i])
                        {
                            newRun[i] = false;
                            return;
                        }

                        if (init[i])
                        {
                            switch (i)
                            {
                                case 0:
                                    target[i] = (face[i].transform.position + (Vector3.forward * dir));
                                    break;

                                case 1:
                                    target[i] = (face[i].transform.position + (Vector3.back * dir));
                                    break;

                                case 2:
                                    target[i] = (face[i].transform.position + (Vector3.right * dir));
                                    break;

                                case 3:
                                    target[i] = (face[i].transform.position + (Vector3.left * dir));
                                    break;

                                case 4:
                                    target[i] = (face[i].transform.position + (Vector3.up * dir));
                                    break;

                                case 5:
                                    target[i] = (face[i].transform.position + (Vector3.down * dir));
                                    break;
                            }

                            init[i] = false;
                        }

                        if (InRange(target[i]))
                        {
                            if (bb[Mathf.RoundToInt(target[i].x - bz.transform.position.x), Mathf.RoundToInt(target[i].y - bz.transform.position.y), Mathf.RoundToInt(target[i].z - bz.transform.position.z)] == null || bb[Mathf.RoundToInt(target[i].x - bz.transform.position.x), Mathf.RoundToInt(target[i].y - bz.transform.position.y), Mathf.RoundToInt(target[i].z - bz.transform.position.z)].transform.IsChildOf(face[i].transform))
                            {
                                face[i].transform.position = Vector3.MoveTowards(face[i].transform.position, target[i], Time.deltaTime);
                            }
                        }

                        if (face[i].transform.position == target[i])
                        {
                            face[i].SetCanStart(false);

                            switch (i)
                            {
                                case 0:
                                    face[i].SetBZSpace(Mathf.RoundToInt(face[i].GetBZSpace().GetBZSpace().x + (Vector3.forward.x * dir)), Mathf.RoundToInt(face[i].GetBZSpace().GetBZSpace().y + (Vector3.forward.y * dir)), Mathf.RoundToInt(face[i].GetBZSpace().GetBZSpace().z + (Vector3.forward.z * dir)));

                                    if (InRange(face[i].GetBZSpace().GetBZSpace() + (Vector3.forward * dir)))
                                    {
                                        Transform[] allChildren = face[i].GetComponentsInChildren<Transform>();

                                        foreach (Transform cb in allChildren)
                                        {
                                            bz.MoveBlock(cb.GetComponent<BaseBlock>(), (Vector3.forward * dir));
                                        }
                                    }

                                    break;

                                case 1:
                                    face[i].SetBZSpace(Mathf.RoundToInt(face[i].GetBZSpace().GetBZSpace().x + (Vector3.back.x * dir)), Mathf.RoundToInt(face[i].GetBZSpace().GetBZSpace().y + (Vector3.back.y * dir)), Mathf.RoundToInt(face[i].GetBZSpace().GetBZSpace().z + (Vector3.back.z * dir)));

                                    if (InRange(face[i].GetBZSpace().GetBZSpace() + (Vector3.back * dir)))
                                    {
                                        Transform[] allChildren = face[i].GetComponentsInChildren<Transform>();

                                        foreach (Transform cb in allChildren)
                                        {
                                            bz.MoveBlock(cb.GetComponent<BaseBlock>(), (Vector3.back * dir));
                                        }
                                    }

                                    break;

                                case 2:
                                    face[i].SetBZSpace(Mathf.RoundToInt(face[i].GetBZSpace().GetBZSpace().x + (Vector3.right.x * dir)), Mathf.RoundToInt(face[i].GetBZSpace().GetBZSpace().y + (Vector3.right.y * dir)), Mathf.RoundToInt(face[i].GetBZSpace().GetBZSpace().z + (Vector3.right.z * dir)));

                                    if (InRange(face[i].GetBZSpace().GetBZSpace() + (Vector3.right * dir)))
                                    {
                                        Transform[] allChildren = face[i].GetComponentsInChildren<Transform>();

                                        foreach (Transform cb in allChildren)
                                        {
                                            bz.MoveBlock(cb.GetComponent<BaseBlock>(), (Vector3.right * dir));
                                        }
                                    }

                                    break;

                                case 3:
                                    face[i].SetBZSpace(Mathf.RoundToInt(face[i].GetBZSpace().GetBZSpace().x + (Vector3.left.x * dir)), Mathf.RoundToInt(face[i].GetBZSpace().GetBZSpace().y + (Vector3.left.y * dir)), Mathf.RoundToInt(face[i].GetBZSpace().GetBZSpace().z + (Vector3.left.z * dir)));

                                    if (InRange(face[i].GetBZSpace().GetBZSpace() + (Vector3.left * dir)))
                                    {
                                        Transform[] allChildren = face[i].GetComponentsInChildren<Transform>();

                                        foreach (Transform cb in allChildren)
                                        {
                                            bz.MoveBlock(cb.GetComponent<BaseBlock>(), (Vector3.left * dir));
                                        }
                                    }

                                    break;

                                case 4:
                                    face[i].SetBZSpace(Mathf.RoundToInt(face[i].GetBZSpace().GetBZSpace().x + (Vector3.up.x * dir)), Mathf.RoundToInt(face[i].GetBZSpace().GetBZSpace().y + (Vector3.up.y * dir)), Mathf.RoundToInt(face[i].GetBZSpace().GetBZSpace().z + (Vector3.up.z * dir)));

                                    if (InRange(face[i].GetBZSpace().GetBZSpace() + (Vector3.up * dir)))
                                    {
                                        Transform[] allChildren = face[i].GetComponentsInChildren<Transform>();

                                        foreach (Transform cb in allChildren)
                                        {
                                            bz.MoveBlock(cb.GetComponent<BaseBlock>(), (Vector3.up * dir));
                                        }
                                    }

                                    break;

                                case 5:
                                    face[i].SetBZSpace(Mathf.RoundToInt(face[i].GetBZSpace().GetBZSpace().x + (Vector3.down.x * dir)), Mathf.RoundToInt(face[i].GetBZSpace().GetBZSpace().y + (Vector3.down.y * dir)), Mathf.RoundToInt(face[i].GetBZSpace().GetBZSpace().z + (Vector3.down.z * dir)));

                                    if (InRange(face[i].GetBZSpace().GetBZSpace() + (Vector3.down * dir)))
                                    {
                                        Transform[] allChildren = face[i].GetComponentsInChildren<Transform>();

                                        foreach (Transform cb in allChildren)
                                        {
                                            bz.MoveBlock(cb.GetComponent<BaseBlock>(), (Vector3.down * dir));
                                        }
                                    }

                                    break;
                            }

                            face[i].SetPriority(7);
                            dir = dir == 1 ? -1 : 1;
                            outwards = outwards == false ? true : false;
                            newRun[i] = true;
                            init[i] = true;
                        }
                    }

                    else
                    {
                        newRun[i] = true;
                    }
                }
            }
        }
    }
}