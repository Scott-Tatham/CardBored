using UnityEngine;
using System.Collections;

public class Slide : BaseBlock
{
    public enum Direction
    {
        FORWARD,
        BACK,
        RIGHT,
        LEFT,
        UP,
        DOWN,
        NULL
    }

    private Vector3[] target = new Vector3[6];
    private Direction[] dir = new Direction[6]
    {
        Direction.RIGHT,
        Direction.LEFT,
        Direction.BACK,
        Direction.FORWARD,
        Direction.RIGHT,
        Direction.LEFT
    };

    protected override void Update()
    {
        base.Update();

        if (et.GetCanDo())
        {
            SlideF();
        }
    }
    // One Side Only
    void SlideF()
    {
        if (InRange(GetBZSpace().GetBZSpace() + Vector3.forward))
        {
            if (bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.forward.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.forward.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.forward.z)] != null && bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.forward.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.forward.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.forward.z)].tag != "StaticBlock" && bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.forward.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.forward.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.forward.z)].tag != "SlideBlock")
            {
                BaseBlock b = bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.forward.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.forward.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.forward.z)];

                if (b.transform.position.x >= target[0].x && b.transform.position.y >= target[0].y && b.transform.position.z >= target[0].z)
                {
                    switch (dir[0])
                    {
                        case Direction.RIGHT:
                            b.SetBZSpace(Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().x + Vector3.right.x), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().y + Vector3.right.y), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().z + Vector3.right.z));
                            bz.MoveBlock(b, Vector3.right);
                            break;

                        case Direction.LEFT:
                            b.SetBZSpace(Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().x + Vector3.left.x), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().y + Vector3.left.y), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().z + Vector3.left.z));
                            bz.MoveBlock(b, Vector3.left);
                            break;

                        case Direction.UP:
                            b.SetBZSpace(Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().x + Vector3.up.x), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().y + Vector3.up.y), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().z + Vector3.up.z));
                            bz.MoveBlock(b, Vector3.up);
                            break;

                        case Direction.DOWN:
                            b.SetBZSpace(Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().x + Vector3.down.x), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().y + Vector3.down.y), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().z + Vector3.down.z));
                            bz.MoveBlock(b, Vector3.down);
                            break;
                    }

                    init[0] = true;
                }

                if (init[0])
                {
                    switch (dir[0])
                    {
                        case Direction.RIGHT:
                            target[0] = b.transform.position + Vector3.right;
                            break;

                        case Direction.LEFT:
                            target[0] = b.transform.position + Vector3.left;
                            break;

                        case Direction.UP:
                            target[0] = b.transform.position + Vector3.up;
                            break;

                        case Direction.DOWN:
                            target[0] = b.transform.position + Vector3.down;
                            break;
                    }

                    init[0] = false;
                }

                Debug.Log(target[0]);

                if (InRange(target[0]))
                {
                    b.transform.position = Vector3.MoveTowards(b.transform.position, target[0], 1 * Time.deltaTime);
                }
            }
        }

        if (InRange(GetBZSpace().GetBZSpace() + Vector3.back))
        {
            if (bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.back.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.back.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.back.z)] != null && bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.back.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.back.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.back.z)].tag != "StaticBlock" && bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.back.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.back.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.back.z)].tag != "SlideBlock")
            {
                BaseBlock b = bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.back.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.back.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.back.z)];

                if (b.transform.position.x >= target[1].x && b.transform.position.y >= target[1].y && b.transform.position.z >= target[1].z)
                {
                    switch (dir[1])
                    {
                        case Direction.RIGHT:
                            b.SetBZSpace(Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().x + Vector3.right.x), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().y + Vector3.right.y), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().z + Vector3.right.z));
                            bz.MoveBlock(b, Vector3.right);
                            break;

                        case Direction.LEFT:
                            b.SetBZSpace(Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().x + Vector3.left.x), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().y + Vector3.left.y), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().z + Vector3.left.z));
                            bz.MoveBlock(b, Vector3.left);
                            break;

                        case Direction.UP:
                            b.SetBZSpace(Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().x + Vector3.up.x), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().y + Vector3.up.y), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().z + Vector3.up.z));
                            bz.MoveBlock(b, Vector3.up);
                            break;

                        case Direction.DOWN:
                            b.SetBZSpace(Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().x + Vector3.down.x), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().y + Vector3.down.y), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().z + Vector3.down.z));
                            bz.MoveBlock(b, Vector3.down);
                            break;
                    }

                    init[1] = true;
                }

                if (init[1])
                {
                    switch (dir[1])
                    {
                        case Direction.RIGHT:
                            target[1] = b.transform.position + Vector3.right;
                            break;

                        case Direction.LEFT:
                            target[1] = b.transform.position + Vector3.left;
                            break;

                        case Direction.UP:
                            target[1] = b.transform.position + Vector3.up;
                            break;

                        case Direction.DOWN:
                            target[1] = b.transform.position + Vector3.down;
                            break;
                    }

                    init[1] = false;
                }

                Debug.Log(target[1]);

                if (InRange(target[1]))
                {
                    b.transform.position = Vector3.MoveTowards(b.transform.position, target[1], 1 * Time.deltaTime);
                }
            }
        }

        if (InRange(GetBZSpace().GetBZSpace() + Vector3.right))
        {
            if (bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.right.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.right.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.right.z)] != null && bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.right.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.right.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.right.z)].tag != "StaticBlock" && bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.right.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.right.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.right.z)].tag != "SlideBlock")
            {
                BaseBlock b = bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.right.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.right.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.right.z)];

                if (b.transform.position.x >= target[2].x && b.transform.position.y >= target[2].y && b.transform.position.z >= target[2].z)
                {
                    switch (dir[2])
                    {
                        case Direction.FORWARD:
                            b.SetBZSpace(Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().x + Vector3.forward.x), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().y + Vector3.forward.y), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().z + Vector3.forward.z));
                            bz.MoveBlock(b, Vector3.forward);
                            break;

                        case Direction.BACK:
                            b.SetBZSpace(Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().x + Vector3.back.x), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().y + Vector3.back.y), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().z + Vector3.back.z));
                            bz.MoveBlock(b, Vector3.back);
                            break;

                        case Direction.UP:
                            b.SetBZSpace(Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().x + Vector3.up.x), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().y + Vector3.up.y), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().z + Vector3.up.z));
                            bz.MoveBlock(b, Vector3.up);
                            break;

                        case Direction.DOWN:
                            b.SetBZSpace(Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().x + Vector3.down.x), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().y + Vector3.down.y), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().z + Vector3.down.z));
                            bz.MoveBlock(b, Vector3.down);
                            break;
                    }

                    init[2] = true;
                }

                if (init[2])
                {
                    switch (dir[2])
                    {
                        case Direction.FORWARD:
                            target[2] = b.transform.position + Vector3.forward;
                            break;

                        case Direction.BACK:
                            target[2] = b.transform.position + Vector3.back;
                            break;

                        case Direction.UP:
                            target[2] = b.transform.position + Vector3.up;
                            break;

                        case Direction.DOWN:
                            target[2] = b.transform.position + Vector3.down;
                            break;
                    }

                    init[2] = false;
                }

                Debug.Log(target[2]);

                if (InRange(target[2]))
                {
                    b.transform.position = Vector3.MoveTowards(b.transform.position, target[2], 1 * Time.deltaTime);
                }
            }
        }

        if (InRange(GetBZSpace().GetBZSpace() + Vector3.left))
        {
            if (bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.left.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.left.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.left.z)] != null && bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.left.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.left.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.left.z)].tag != "StaticBlock" && bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.left.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.left.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.left.z)].tag != "SlideBlock")
            {
                BaseBlock b = bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.left.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.left.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.left.z)];

                if (b.transform.position.x >= target[3].x && b.transform.position.y >= target[3].y && b.transform.position.z >= target[3].z)
                {
                    switch (dir[3])
                    {
                        case Direction.FORWARD:
                            b.SetBZSpace(Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().x + Vector3.forward.x), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().y + Vector3.forward.y), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().z + Vector3.forward.z));
                            bz.MoveBlock(b, Vector3.forward);
                            break;

                        case Direction.BACK:
                            b.SetBZSpace(Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().x + Vector3.back.x), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().y + Vector3.back.y), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().z + Vector3.back.z));
                            bz.MoveBlock(b, Vector3.back);
                            break;

                        case Direction.UP:
                            b.SetBZSpace(Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().x + Vector3.up.x), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().y + Vector3.up.y), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().z + Vector3.up.z));
                            bz.MoveBlock(b, Vector3.up);
                            break;

                        case Direction.DOWN:
                            b.SetBZSpace(Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().x + Vector3.down.x), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().y + Vector3.down.y), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().z + Vector3.down.z));
                            bz.MoveBlock(b, Vector3.down);
                            break;
                    }

                    init[3] = true;
                }

                if (init[3])
                {
                    switch (dir[3])
                    {
                        case Direction.FORWARD:
                            target[3] = b.transform.position + Vector3.forward;
                            break;

                        case Direction.BACK:
                            target[3] = b.transform.position + Vector3.back;
                            break;

                        case Direction.UP:
                            target[3] = b.transform.position + Vector3.up;
                            break;

                        case Direction.DOWN:
                            target[3] = b.transform.position + Vector3.down;
                            break;
                    }

                    init[3] = false;
                }

                Debug.Log(target[3]);

                if (InRange(target[3]))
                {
                    b.transform.position = Vector3.MoveTowards(b.transform.position, target[3], 1 * Time.deltaTime);
                }
            }
        }

        if (InRange(GetBZSpace().GetBZSpace() + Vector3.up))
        {
            if (bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.up.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.up.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.up.z)] != null && bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.up.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.up.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.up.z)].tag != "StaticBlock" && bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.up.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.up.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.up.z)].tag != "SlideBlock")
            {
                BaseBlock b = bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.up.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.up.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.up.z)];

                if (b.transform.position.x >= target[4].x && b.transform.position.y >= target[4].y && b.transform.position.z >= target[4].z)
                {
                    switch (dir[4])
                    {
                        case Direction.FORWARD:
                            b.SetBZSpace(Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().x + Vector3.forward.x), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().y + Vector3.forward.y), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().z + Vector3.forward.z));
                            bz.MoveBlock(b, Vector3.forward);
                            break;

                        case Direction.BACK:
                            b.SetBZSpace(Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().x + Vector3.back.x), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().y + Vector3.back.y), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().z + Vector3.back.z));
                            bz.MoveBlock(b, Vector3.back);
                            break;

                        case Direction.RIGHT:
                            b.SetBZSpace(Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().x + Vector3.right.x), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().y + Vector3.right.y), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().z + Vector3.right.z));
                            bz.MoveBlock(b, Vector3.right);
                            break;

                        case Direction.LEFT:
                            b.SetBZSpace(Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().x + Vector3.left.x), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().y + Vector3.left.y), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().z + Vector3.left.z));
                            bz.MoveBlock(b, Vector3.left);
                            break;
                    }

                    init[4] = true;
                }

                if (init[4])
                {
                    switch (dir[4])
                    {
                        case Direction.FORWARD:
                            target[4] = b.transform.position + Vector3.forward;
                            break;

                        case Direction.BACK:
                            target[4] = b.transform.position + Vector3.back;
                            break;

                        case Direction.RIGHT:
                            target[4] = b.transform.position + Vector3.right;
                            break;

                        case Direction.LEFT:
                            target[4] = b.transform.position + Vector3.left;
                            break;
                    }

                    init[4] = false;
                }

                Debug.Log(target[4]);

                if (InRange(target[4]))
                {
                    b.transform.position = Vector3.MoveTowards(b.transform.position, target[4], 1 * Time.deltaTime);
                }
            }
        }

        if (InRange(GetBZSpace().GetBZSpace() + Vector3.down))
        {
            if (bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.down.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.down.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.down.z)] != null && bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.down.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.down.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.down.z)].tag != "StaticBlock" && bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.down.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.down.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.down.z)].tag != "SlideBlock")
            {
                BaseBlock b = bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.down.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.down.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.down.z)];

                if (b.transform.position.x >= target[5].x && b.transform.position.y >= target[5].y && b.transform.position.z >= target[5].z)
                {
                    switch (dir[5])
                    {
                        case Direction.FORWARD:
                            b.SetBZSpace(Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().x + Vector3.forward.x), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().y + Vector3.forward.y), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().z + Vector3.forward.z));
                            bz.MoveBlock(b, Vector3.forward);
                            break;

                        case Direction.BACK:
                            b.SetBZSpace(Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().x + Vector3.back.x), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().y + Vector3.back.y), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().z + Vector3.back.z));
                            bz.MoveBlock(b, Vector3.back);
                            break;

                        case Direction.RIGHT:
                            b.SetBZSpace(Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().x + Vector3.right.x), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().y + Vector3.right.y), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().z + Vector3.right.z));
                            bz.MoveBlock(b, Vector3.right);
                            break;

                        case Direction.LEFT:
                            b.SetBZSpace(Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().x + Vector3.left.x), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().y + Vector3.left.y), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().z + Vector3.left.z));
                            bz.MoveBlock(b, Vector3.left);

                            break;
                    }

                    late[5] = true;
                    init[5] = true;
                }

                if (init[5])
                {
                    switch (dir[5])
                    {
                        case Direction.FORWARD:
                            target[5] = b.transform.position + Vector3.forward;
                            break;

                        case Direction.BACK:
                            target[5] = b.transform.position + Vector3.back;
                            break;

                        case Direction.RIGHT:
                            target[5] = b.transform.position + Vector3.right;
                            break;

                        case Direction.LEFT:
                            target[5] = b.transform.position + Vector3.left;
                            break;
                    }

                    init[5] = false;
                }

                Debug.Log(target[5]);

                if (InRange(target[5]))
                {
                    b.transform.position = Vector3.MoveTowards(b.transform.position, target[5], 1 * Time.deltaTime);
                }
            }
        }
    }
}