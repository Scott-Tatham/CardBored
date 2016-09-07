using UnityEngine;
using System.Collections;

public class Rotate : PowerNode
{
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
            if (isActive[0] && isPowered)
            {
                Debug.Log("Here");
                if (InRange(GetBZSpace().GetBZSpace() + Vector3.forward))
                {
                    if (bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.forward.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.forward.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.forward.z)] != null && bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.forward.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.forward.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.forward.z)].transform.parent == null && bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.forward.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.forward.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.forward.z)].tag != "StaticBlock" && bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.forward.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.forward.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.forward.z)].tag != "SlideBlock" && bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.forward.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.forward.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.forward.z)].tag != "RotateBlock")
                    {
                        BaseBlock b = bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.forward.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.forward.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.forward.z)];

                        if (b.GetCanStart())
                        {
                            if (dir[0])
                            {
                                b.transform.RotateAround(transform.position, (b.transform.position - transform.position).normalized, 2.0f);
                            }

                            else
                            {
                                b.transform.RotateAround(transform.position, (b.transform.position - transform.position).normalized, 2.0f);
                            }
                        }
                    }
                }
            }

            if (isActive[1] && isPowered)
            {
                Debug.Log("Here");
                if (InRange(GetBZSpace().GetBZSpace() + Vector3.back))
                {
                    if (bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.back.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.back.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.back.z)] != null && bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.back.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.back.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.back.z)].transform.parent == null && bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.back.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.back.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.back.z)].tag != "StaticBlock" && bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.back.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.back.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.back.z)].tag != "SlideBlock" && bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.back.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.back.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.back.z)].tag != "RotateBlock")
                    {
                        BaseBlock b = bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.back.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.back.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.back.z)];

                        if (b.GetCanStart())
                        {
                            if (dir[1])
                            {
                                b.transform.RotateAround(transform.position, (b.transform.position - transform.position).normalized, 2.0f);
                            }

                            else
                            {
                                b.transform.RotateAround(transform.position, (b.transform.position - transform.position).normalized, -2.0f);
                            }
                        }
                    }
                }
            }

            if (isActive[2] && isPowered)
            {
                Debug.Log("Here");
                if (InRange(GetBZSpace().GetBZSpace() + Vector3.right))
                {
                    if (bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.right.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.right.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.right.z)] != null && bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.right.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.right.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.right.z)].transform.parent == null && bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.right.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.right.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.right.z)].tag != "StaticBlock" && bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.right.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.right.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.right.z)].tag != "SlideBlock" && bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.right.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.right.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.right.z)].tag != "RotateBlock")
                    {
                        BaseBlock b = bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.right.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.right.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.right.z)];

                        if (b.GetCanStart())
                        {
                            if (dir[2])
                            {
                                b.transform.RotateAround(transform.position, (b.transform.position - transform.position).normalized, 2.0f);
                            }

                            else
                            {
                                b.transform.RotateAround(transform.position, (b.transform.position - transform.position).normalized, -2.0f);
                            }
                        }
                    }
                }
            }

            if (isActive[3] && isPowered)
            {
                Debug.Log("Here");
                if (InRange(GetBZSpace().GetBZSpace() + Vector3.left))
                {
                    if (bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.left.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.left.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.left.z)] != null && bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.left.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.left.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.left.z)].transform.parent == null && bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.left.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.left.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.left.z)].tag != "StaticBlock" && bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.left.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.left.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.left.z)].tag != "SlideBlock" && bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.left.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.left.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.left.z)].tag != "RotateBlock")
                    {
                        BaseBlock b = bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.left.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.left.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.left.z)];

                        if (b.GetCanStart())
                        {
                            if (dir[3])
                            {
                                b.transform.RotateAround(transform.position, (b.transform.position - transform.position).normalized, 2.0f);
                            }

                            else
                            {
                                b.transform.RotateAround(transform.position, (b.transform.position - transform.position).normalized, -2.0f);
                            }
                        }
                    }
                }
            }

            if (isActive[4] && isPowered)
            {
                Debug.Log("Here");
                if (InRange(GetBZSpace().GetBZSpace() + Vector3.up))
                {
                    if (bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.up.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.up.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.up.z)] != null && bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.up.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.up.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.up.z)].transform.parent == null && bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.up.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.up.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.up.z)].tag != "StaticBlock" && bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.up.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.up.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.up.z)].tag != "SlideBlock" && bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.up.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.up.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.up.z)].tag != "RotateBlock")
                    {
                        BaseBlock b = bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.up.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.up.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.up.z)];

                        if (b.GetCanStart())
                        {
                            if (dir[4])
                            {
                                b.transform.RotateAround(transform.position, (b.transform.position - transform.position).normalized, 2.0f);
                            }

                            else
                            {
                                b.transform.RotateAround(transform.position, (b.transform.position - transform.position).normalized, -2.0f);
                            }
                        }
                    }
                }
            }

            if (isActive[5] && isPowered)
            {
                Debug.Log("Here");
                if (InRange(GetBZSpace().GetBZSpace() + Vector3.down))
                {
                    if (bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.down.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.down.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.down.z)] != null && bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.down.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.down.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.down.z)].transform.parent == null && bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.down.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.down.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.down.z)].tag != "StaticBlock" && bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.down.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.down.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.down.z)].tag != "SlideBlock" && bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.down.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.down.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.down.z)].tag != "RotateBlock")
                    {
                        BaseBlock b = bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.down.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.down.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.down.z)];

                        if (b.GetCanStart())
                        {
                            if (dir[5])
                            {
                                b.transform.RotateAround(transform.position, (b.transform.position - transform.position).normalized, 2.0f);
                            }

                            else
                            {
                                b.transform.RotateAround(transform.position, (b.transform.position - transform.position).normalized, -2.0f);
                            }
                        }
                    }
                }
            }
        }
    }
}