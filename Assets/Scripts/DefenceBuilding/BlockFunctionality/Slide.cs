using UnityEngine;
using System.Collections;

public class Slide : PowerNode
{
    public enum Direction
    {
        FORWARD,
        BACK,
        RIGHT,
        LEFT,
        UP,
        DOWN
    }

    bool first;
    bool[] init = new bool[6] { true, true, true, true, true, true };
    bool[] newRun = new bool[6] { true, true, true, true, true, true };
    Vector3[] target = new Vector3[6];
    Direction[] dir = new Direction[6] { Direction.RIGHT, Direction.LEFT, Direction.BACK, Direction.FORWARD, Direction.RIGHT, Direction.LEFT };

    protected override void Start()
    {
        for (int i = 0; i < 6; i++)
        {
            if (i == 3)
            {
                GetComponent<BoxUVs>().SetSide(i, BoxUVs.Side.SLIDER);
            }

            else
            {
                GetComponent<BoxUVs>().SetSide(i, BoxUVs.Side.SLIDEL);
            }
        }
    }

    protected override void Update()
    {
        base.Update();

        if (!et.GetCanDo() && !first)
        {
            first = true;
        }

        if (et.GetCanDo() && first)
        {
            SlideF();
        }
    }

    void SlideF()
    {
        SetFace();

        for (int i = 0; i < face.Length; i++)
        {
            if (isActive[i] && isPowered)
            {
                if (face[i].transform.parent == null && face[i].GetComponent<Static>() == null)
                {
                    if (face[i].IsMaster(i) && face[i].GetCanStart())
                    {
                        if (newRun[i])
                        {
                            newRun[i] = false;
                            return;
                        }

                        if (init[i])
                        {
                            switch (dir[i])
                            {
                                case Direction.FORWARD:
                                    target[i] = face[i].transform.position + Vector3.forward;
                                    
                                    break;

                                case Direction.BACK:
                                    target[i] = face[i].transform.position + Vector3.back;

                                    break;

                                case Direction.RIGHT:
                                    target[i] = face[i].transform.position + Vector3.right;

                                    break;

                                case Direction.LEFT:
                                    target[i] = face[i].transform.position + Vector3.left;

                                    break;

                                case Direction.UP:
                                    target[i] = face[i].transform.position + Vector3.up;

                                    break;

                                case Direction.DOWN:
                                    target[i] = face[i].transform.position + Vector3.down;

                                    break;
                            }

                            init[i] = false;
                        }

                        // True for all children.
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

                            switch (dir[i])
                            {
                                case Direction.FORWARD:
                                    face[i].SetBZSpace(Mathf.RoundToInt(face[i].GetBZSpace().GetBZSpace().x + Vector3.forward.x), Mathf.RoundToInt(face[i].GetBZSpace().GetBZSpace().y + Vector3.forward.y), Mathf.RoundToInt(face[i].GetBZSpace().GetBZSpace().z + Vector3.forward.z));

                                    if (InRange(face[i].GetBZSpace().GetBZSpace() + Vector3.forward))
                                    {
                                        Transform[] allChildren = face[i].GetComponentsInChildren<Transform>();

                                        foreach (Transform cb in allChildren)
                                        {
                                            bz.MoveBlock(cb.GetComponent<BaseBlock>(), Vector3.forward);
                                        }
                                    }

                                    break;

                                case Direction.BACK:
                                    face[i].SetBZSpace(Mathf.RoundToInt(face[i].GetBZSpace().GetBZSpace().x + Vector3.back.x), Mathf.RoundToInt(face[i].GetBZSpace().GetBZSpace().y + Vector3.back.y), Mathf.RoundToInt(face[i].GetBZSpace().GetBZSpace().z + Vector3.back.z));

                                    if (InRange(face[i].GetBZSpace().GetBZSpace() + Vector3.back))
                                    {
                                        Transform[] allChildren = face[i].GetComponentsInChildren<Transform>();

                                        foreach (Transform cb in allChildren)
                                        {
                                            bz.MoveBlock(cb.GetComponent<BaseBlock>(), Vector3.back);
                                        }
                                    }

                                    break;

                                case Direction.RIGHT:
                                    face[i].SetBZSpace(Mathf.RoundToInt(face[i].GetBZSpace().GetBZSpace().x + Vector3.right.x), Mathf.RoundToInt(face[i].GetBZSpace().GetBZSpace().y + Vector3.right.y), Mathf.RoundToInt(face[i].GetBZSpace().GetBZSpace().z + Vector3.right.z));

                                    if (InRange(face[i].GetBZSpace().GetBZSpace() + Vector3.right))
                                    {
                                        Transform[] allChildren = face[i].GetComponentsInChildren<Transform>();

                                        foreach (Transform cb in allChildren)
                                        {
                                            bz.MoveBlock(cb.GetComponent<BaseBlock>(), Vector3.right);
                                        }
                                    }

                                    break;

                                case Direction.LEFT:
                                    face[i].SetBZSpace(Mathf.RoundToInt(face[i].GetBZSpace().GetBZSpace().x + Vector3.left.x), Mathf.RoundToInt(face[i].GetBZSpace().GetBZSpace().y + Vector3.left.y), Mathf.RoundToInt(face[i].GetBZSpace().GetBZSpace().z + Vector3.left.z));

                                    if (InRange(face[i].GetBZSpace().GetBZSpace() + Vector3.left))
                                    {
                                        Transform[] allChildren = face[i].GetComponentsInChildren<Transform>();

                                        foreach (Transform cb in allChildren)
                                        {
                                            bz.MoveBlock(cb.GetComponent<BaseBlock>(), Vector3.left);
                                        }
                                    }

                                    break;

                                case Direction.UP:
                                    face[i].SetBZSpace(Mathf.RoundToInt(face[i].GetBZSpace().GetBZSpace().x + Vector3.up.x), Mathf.RoundToInt(face[i].GetBZSpace().GetBZSpace().y + Vector3.up.y), Mathf.RoundToInt(face[i].GetBZSpace().GetBZSpace().z + Vector3.up.z));

                                    if (InRange(face[i].GetBZSpace().GetBZSpace() + Vector3.up))
                                    {
                                        Transform[] allChildren = face[i].GetComponentsInChildren<Transform>();

                                        foreach (Transform cb in allChildren)
                                        {
                                            bz.MoveBlock(cb.GetComponent<BaseBlock>(), Vector3.up);
                                        }
                                    }

                                    break;

                                case Direction.DOWN:
                                    face[i].SetBZSpace(Mathf.RoundToInt(face[i].GetBZSpace().GetBZSpace().x + Vector3.down.x), Mathf.RoundToInt(face[i].GetBZSpace().GetBZSpace().y + Vector3.down.y), Mathf.RoundToInt(face[i].GetBZSpace().GetBZSpace().z + Vector3.down.z));

                                    if (InRange(face[i].GetBZSpace().GetBZSpace() + Vector3.down))
                                    {
                                        Transform[] allChildren = face[i].GetComponentsInChildren<Transform>();

                                        foreach (Transform cb in allChildren)
                                        {
                                            bz.MoveBlock(cb.GetComponent<BaseBlock>(), Vector3.down);
                                        }
                                    }

                                    break;
                            }

                            face[i].SetPriority(7);
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