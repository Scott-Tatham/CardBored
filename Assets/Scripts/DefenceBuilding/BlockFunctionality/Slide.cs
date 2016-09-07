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
        DOWN,
        NULL
    }

    bool[] init = new bool[6] { true, true, true, true, true, true };
    bool[] newRun = new bool[6] { true, true, true, true, true, true };
    Vector3[] target = new Vector3[6];
    Direction[] dir = new Direction[6]
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

    void SlideF()
    {
        if (isActive[0] && isPowered)
        {
            if (InRange(GetBZSpace().GetBZSpace() + Vector3.forward))
            {
                if (bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.forward.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.forward.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.forward.z)] != null && bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.forward.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.forward.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.forward.z)].transform.parent == null && bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.forward.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.forward.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.forward.z)].tag != "StaticBlock" && bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.forward.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.forward.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.forward.z)].tag != "SlideBlock" && bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.forward.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.forward.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.forward.z)].tag != "RotateBlock")
                {
                    BaseBlock b = bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.forward.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.forward.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.forward.z)];

                    if (b.IsMaster(3) && b.GetCanStart())
                    {
                        if (newRun[0])
                        {
                            newRun[0] = false;
                            return;
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

                        if (InRange(target[0]))
                        {
                            if (bb[Mathf.RoundToInt(target[0].x - bz.transform.position.x), Mathf.RoundToInt(target[0].y - bz.transform.position.y), Mathf.RoundToInt(target[0].z - bz.transform.position.z)] == null || bb[Mathf.RoundToInt(target[0].x - bz.transform.position.x), Mathf.RoundToInt(target[0].y - bz.transform.position.y), Mathf.RoundToInt(target[0].z - bz.transform.position.z)].transform.IsChildOf(b.transform))
                            {
                                b.transform.position = Vector3.MoveTowards(b.transform.position, target[0], 1 * Time.deltaTime);
                            }
                        }

                        if (b.transform.position.x == target[0].x && b.transform.position.y == target[0].y && b.transform.position.z == target[0].z)
                        {
                            b.SetCanStart(false);

                            switch (dir[0])
                            {
                                case Direction.RIGHT:
                                    b.SetBZSpace(Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().x + Vector3.right.x), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().y + Vector3.right.y), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().z + Vector3.right.z));

                                    if (InRange(b.GetBZSpace().GetBZSpace() + Vector3.right))
                                    {
                                        Transform[] allChildren = b.GetComponentsInChildren<Transform>();

                                        foreach (Transform cb in allChildren)
                                        {
                                            bz.MoveBlock(cb.GetComponent<BaseBlock>(), Vector3.right);
                                        }
                                    }

                                    break;

                                case Direction.LEFT:
                                    b.SetBZSpace(Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().x + Vector3.left.x), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().y + Vector3.left.y), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().z + Vector3.left.z));

                                    if (InRange(b.GetBZSpace().GetBZSpace() + Vector3.left))
                                    {
                                        Transform[] allChildren = b.GetComponentsInChildren<Transform>();

                                        foreach (Transform cb in allChildren)
                                        {
                                            bz.MoveBlock(cb.GetComponent<BaseBlock>(), Vector3.left);
                                        }
                                    }

                                    break;

                                case Direction.UP:
                                    b.SetBZSpace(Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().x + Vector3.up.x), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().y + Vector3.up.y), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().z + Vector3.up.z));

                                    if (InRange(b.GetBZSpace().GetBZSpace() + Vector3.up))
                                    {
                                        Transform[] allChildren = b.GetComponentsInChildren<Transform>();

                                        foreach (Transform cb in allChildren)
                                        {
                                            bz.MoveBlock(cb.GetComponent<BaseBlock>(), Vector3.up);
                                        }
                                    }

                                    break;

                                case Direction.DOWN:
                                    b.SetBZSpace(Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().x + Vector3.down.x), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().y + Vector3.down.y), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().z + Vector3.down.z));

                                    if (InRange(b.GetBZSpace().GetBZSpace() + Vector3.down))
                                    {
                                        Transform[] allChildren = b.GetComponentsInChildren<Transform>();

                                        foreach (Transform cb in allChildren)
                                        {
                                            bz.MoveBlock(cb.GetComponent<BaseBlock>(), Vector3.down);
                                        }
                                    }

                                    break;
                            }

                            b.SetPriority(7);
                            newRun[0] = true;
                            init[0] = true;
                        }
                    }

                    else
                    {
                        newRun[0] = true;
                    }
                }
            }
        }

        if (isActive[1] && isPowered)
        {
            if (InRange(GetBZSpace().GetBZSpace() + Vector3.back))
            {
                if (bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.back.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.back.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.back.z)] != null && bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.back.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.back.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.back.z)].transform.parent == null && bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.back.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.back.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.back.z)].tag != "StaticBlock" && bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.back.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.back.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.back.z)].tag != "SlideBlock" && bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.back.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.back.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.back.z)].tag != "RotateBlock")
                {
                    BaseBlock b = bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.back.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.back.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.back.z)];

                    if (b.IsMaster(4) && b.GetCanStart())
                    {
                        if (newRun[1])
                        {
                            newRun[1] = false;
                            return;
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

                        if (InRange(target[1]))
                        {
                            if (bb[Mathf.RoundToInt(target[0].x - bz.transform.position.x), Mathf.RoundToInt(target[0].y - bz.transform.position.y), Mathf.RoundToInt(target[0].z - bz.transform.position.z)] == null || bb[Mathf.RoundToInt(target[0].x - bz.transform.position.x), Mathf.RoundToInt(target[0].y - bz.transform.position.y), Mathf.RoundToInt(target[0].z - bz.transform.position.z)].transform.IsChildOf(b.transform))
                            {
                                b.transform.position = Vector3.MoveTowards(b.transform.position, target[1], 1 * Time.deltaTime);
                            }
                        }

                        if (b.transform.position.x == target[1].x && b.transform.position.y == target[1].y && b.transform.position.z == target[1].z)
                        {
                            b.SetCanStart(false);

                            switch (dir[1])
                            {
                                case Direction.RIGHT:
                                    b.SetBZSpace(Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().x + Vector3.right.x), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().y + Vector3.right.y), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().z + Vector3.right.z));

                                    if (InRange(b.GetBZSpace().GetBZSpace() + Vector3.right))
                                    {
                                        Transform[] allChildren = b.GetComponentsInChildren<Transform>();

                                        foreach (Transform cb in allChildren)
                                        {
                                            bz.MoveBlock(cb.GetComponent<BaseBlock>(), Vector3.right);
                                        }
                                    }

                                    break;

                                case Direction.LEFT:
                                    b.SetBZSpace(Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().x + Vector3.left.x), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().y + Vector3.left.y), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().z + Vector3.left.z));

                                    if (InRange(b.GetBZSpace().GetBZSpace() + Vector3.left))
                                    {
                                        Transform[] allChildren = b.GetComponentsInChildren<Transform>();

                                        foreach (Transform cb in allChildren)
                                        {
                                            bz.MoveBlock(cb.GetComponent<BaseBlock>(), Vector3.left);
                                        }
                                    }

                                    break;

                                case Direction.UP:
                                    b.SetBZSpace(Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().x + Vector3.up.x), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().y + Vector3.up.y), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().z + Vector3.up.z));

                                    if (InRange(b.GetBZSpace().GetBZSpace() + Vector3.up))
                                    {
                                        Transform[] allChildren = b.GetComponentsInChildren<Transform>();

                                        foreach (Transform cb in allChildren)
                                        {
                                            bz.MoveBlock(cb.GetComponent<BaseBlock>(), Vector3.up);
                                        }
                                    }

                                    break;

                                case Direction.DOWN:
                                    b.SetBZSpace(Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().x + Vector3.down.x), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().y + Vector3.down.y), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().z + Vector3.down.z));

                                    if (InRange(b.GetBZSpace().GetBZSpace() + Vector3.down))
                                    {
                                        Transform[] allChildren = b.GetComponentsInChildren<Transform>();

                                        foreach (Transform cb in allChildren)
                                        {
                                            bz.MoveBlock(cb.GetComponent<BaseBlock>(), Vector3.down);
                                        }
                                    }

                                    break;
                            }

                            b.SetPriority(7);
                            newRun[1] = true;
                            init[1] = true;
                        }
                    }

                    else
                    {
                        newRun[1] = true;
                    }
                }
            }
        }

        if (isActive[2] && isPowered)
        {
            if (InRange(GetBZSpace().GetBZSpace() + Vector3.right))
            {
                if (bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.right.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.right.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.right.z)] != null && bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.right.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.right.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.right.z)].transform.parent == null && bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.right.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.right.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.right.z)].tag != "StaticBlock" && bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.right.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.right.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.right.z)].tag != "SlideBlock" && bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.right.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.right.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.right.z)].tag != "RotateBlock")
                {
                    BaseBlock b = bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.right.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.right.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.right.z)];

                    if (b.IsMaster(5) && b.GetCanStart())
                    {
                        if (newRun[2])
                        {
                            newRun[2] = false;
                            return;
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

                        if (InRange(target[2]))
                        {
                            if (bb[Mathf.RoundToInt(target[0].x - bz.transform.position.x), Mathf.RoundToInt(target[0].y - bz.transform.position.y), Mathf.RoundToInt(target[0].z - bz.transform.position.z)] == null || bb[Mathf.RoundToInt(target[0].x - bz.transform.position.x), Mathf.RoundToInt(target[0].y - bz.transform.position.y), Mathf.RoundToInt(target[0].z - bz.transform.position.z)].transform.IsChildOf(b.transform))
                            {
                                b.transform.position = Vector3.MoveTowards(b.transform.position, target[2], 1 * Time.deltaTime);
                            }
                        }

                        if (b.transform.position.x == target[2].x && b.transform.position.y == target[2].y && b.transform.position.z == target[2].z)
                        {
                            b.SetCanStart(false);

                            switch (dir[2])
                            {
                                case Direction.FORWARD:
                                    b.SetBZSpace(Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().x + Vector3.forward.x), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().y + Vector3.forward.y), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().z + Vector3.forward.z));

                                    if (InRange(b.GetBZSpace().GetBZSpace() + Vector3.forward))
                                    {
                                        Transform[] allChildren = b.GetComponentsInChildren<Transform>();

                                        foreach (Transform cb in allChildren)
                                        {
                                            bz.MoveBlock(cb.GetComponent<BaseBlock>(), Vector3.forward);
                                        }
                                    }

                                    break;

                                case Direction.BACK:
                                    b.SetBZSpace(Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().x + Vector3.back.x), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().y + Vector3.back.y), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().z + Vector3.back.z));

                                    if (InRange(b.GetBZSpace().GetBZSpace() + Vector3.back))
                                    {
                                        Transform[] allChildren = b.GetComponentsInChildren<Transform>();

                                        foreach (Transform cb in allChildren)
                                        {
                                            bz.MoveBlock(cb.GetComponent<BaseBlock>(), Vector3.back);
                                        }
                                    }
                                    break;

                                case Direction.UP:
                                    b.SetBZSpace(Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().x + Vector3.up.x), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().y + Vector3.up.y), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().z + Vector3.up.z));

                                    if (InRange(b.GetBZSpace().GetBZSpace() + Vector3.up))
                                    {
                                        Transform[] allChildren = b.GetComponentsInChildren<Transform>();

                                        foreach (Transform cb in allChildren)
                                        {
                                            bz.MoveBlock(cb.GetComponent<BaseBlock>(), Vector3.up);
                                        }
                                    }

                                    break;

                                case Direction.DOWN:
                                    b.SetBZSpace(Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().x + Vector3.down.x), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().y + Vector3.down.y), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().z + Vector3.down.z));

                                    if (InRange(b.GetBZSpace().GetBZSpace() + Vector3.down))
                                    {
                                        Transform[] allChildren = b.GetComponentsInChildren<Transform>();

                                        foreach (Transform cb in allChildren)
                                        {
                                            bz.MoveBlock(cb.GetComponent<BaseBlock>(), Vector3.down);
                                        }
                                    }

                                    break;
                            }

                            b.SetPriority(7);
                            newRun[2] = true;
                            init[2] = true;
                        }
                    }

                    else
                    {
                        newRun[2] = true;
                    }
                }
            }
        }

        if (isActive[3] && isPowered)
        {
            if (InRange(GetBZSpace().GetBZSpace() + Vector3.left))
            {
                if (bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.left.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.left.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.left.z)] != null && bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.left.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.left.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.left.z)].transform.parent == null && bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.left.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.left.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.left.z)].tag != "StaticBlock" && bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.left.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.left.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.left.z)].tag != "SlideBlock" && bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.left.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.left.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.left.z)].tag != "RotateBlock")
                {
                    BaseBlock b = bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.left.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.left.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.left.z)];

                    if (b.IsMaster(6) && b.GetCanStart())
                    {
                        if (newRun[3])
                        {
                            newRun[3] = false;
                            return;
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

                        if (InRange(target[3]))
                        {
                            if (bb[Mathf.RoundToInt(target[0].x - bz.transform.position.x), Mathf.RoundToInt(target[0].y - bz.transform.position.y), Mathf.RoundToInt(target[0].z - bz.transform.position.z)] == null || bb[Mathf.RoundToInt(target[0].x - bz.transform.position.x), Mathf.RoundToInt(target[0].y - bz.transform.position.y), Mathf.RoundToInt(target[0].z - bz.transform.position.z)].transform.IsChildOf(b.transform))
                            {
                                b.transform.position = Vector3.MoveTowards(b.transform.position, target[3], 1 * Time.deltaTime);
                            }
                        }

                        if (b.transform.position.x == target[3].x && b.transform.position.y == target[3].y && b.transform.position.z == target[3].z)
                        {
                            b.SetCanStart(false);

                            switch (dir[3])
                            {
                                case Direction.FORWARD:
                                    b.SetBZSpace(Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().x + Vector3.forward.x), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().y + Vector3.forward.y), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().z + Vector3.forward.z));

                                    if (InRange(b.GetBZSpace().GetBZSpace() + Vector3.forward))
                                    {
                                        Transform[] allChildren = b.GetComponentsInChildren<Transform>();

                                        foreach (Transform cb in allChildren)
                                        {
                                            bz.MoveBlock(cb.GetComponent<BaseBlock>(), Vector3.forward);
                                        }
                                    }

                                    break;

                                case Direction.BACK:
                                    b.SetBZSpace(Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().x + Vector3.back.x), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().y + Vector3.back.y), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().z + Vector3.back.z));

                                    if (InRange(b.GetBZSpace().GetBZSpace() + Vector3.back))
                                    {
                                        Transform[] allChildren = b.GetComponentsInChildren<Transform>();

                                        foreach (Transform cb in allChildren)
                                        {
                                            bz.MoveBlock(cb.GetComponent<BaseBlock>(), Vector3.back);
                                        }
                                    }

                                    break;

                                case Direction.UP:
                                    b.SetBZSpace(Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().x + Vector3.up.x), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().y + Vector3.up.y), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().z + Vector3.up.z));

                                    if (InRange(b.GetBZSpace().GetBZSpace() + Vector3.up))
                                    {
                                        Transform[] allChildren = b.GetComponentsInChildren<Transform>();

                                        foreach (Transform cb in allChildren)
                                        {
                                            bz.MoveBlock(cb.GetComponent<BaseBlock>(), Vector3.up);
                                        }
                                    }

                                    break;

                                case Direction.DOWN:
                                    b.SetBZSpace(Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().x + Vector3.down.x), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().y + Vector3.down.y), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().z + Vector3.down.z));

                                    if (InRange(b.GetBZSpace().GetBZSpace() + Vector3.down))
                                    {
                                        Transform[] allChildren = b.GetComponentsInChildren<Transform>();

                                        foreach (Transform cb in allChildren)
                                        {
                                            bz.MoveBlock(cb.GetComponent<BaseBlock>(), Vector3.down);
                                        }
                                    }

                                    break;
                            }

                            b.SetPriority(7);
                            newRun[3] = true;
                            init[3] = true;
                        }
                    }

                    else
                    {
                        newRun[3] = true;
                    }
                }
            }
        }

        if (isActive[4] && isPowered)
        {
            if (InRange(GetBZSpace().GetBZSpace() + Vector3.up))
            {
                if (bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.up.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.up.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.up.z)] != null && bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.up.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.up.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.up.z)].transform.parent == null && bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.up.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.up.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.up.z)].tag != "StaticBlock" && bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.up.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.up.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.up.z)].tag != "SlideBlock" && bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.up.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.up.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.up.z)].tag != "RotateBlock")
                {
                    BaseBlock b = bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.up.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.up.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.up.z)];

                    if (b.IsMaster(1) && b.GetCanStart())
                    {
                        if (newRun[4])
                        {
                            newRun[4] = false;
                            return;
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

                        if (InRange(target[4]))
                        {
                            if (bb[Mathf.RoundToInt(target[0].x - bz.transform.position.x), Mathf.RoundToInt(target[0].y - bz.transform.position.y), Mathf.RoundToInt(target[0].z - bz.transform.position.z)] == null || bb[Mathf.RoundToInt(target[0].x - bz.transform.position.x), Mathf.RoundToInt(target[0].y - bz.transform.position.y), Mathf.RoundToInt(target[0].z - bz.transform.position.z)].transform.IsChildOf(b.transform))
                            {
                                b.transform.position = Vector3.MoveTowards(b.transform.position, target[4], 1 * Time.deltaTime);
                            }
                        }

                        if (b.transform.position.x == target[4].x && b.transform.position.y == target[4].y && b.transform.position.z == target[4].z)
                        {
                            b.SetCanStart(false);

                            switch (dir[4])
                            {
                                case Direction.FORWARD:
                                    b.SetBZSpace(Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().x + Vector3.forward.x), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().y + Vector3.forward.y), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().z + Vector3.forward.z));

                                    if (InRange(b.GetBZSpace().GetBZSpace() + Vector3.forward))
                                    {
                                        Transform[] allChildren = b.GetComponentsInChildren<Transform>();

                                        foreach (Transform cb in allChildren)
                                        {
                                            bz.MoveBlock(cb.GetComponent<BaseBlock>(), Vector3.forward);
                                        }
                                    }

                                    break;

                                case Direction.BACK:
                                    b.SetBZSpace(Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().x + Vector3.back.x), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().y + Vector3.back.y), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().z + Vector3.back.z));

                                    if (InRange(b.GetBZSpace().GetBZSpace() + Vector3.back))
                                    {
                                        Transform[] allChildren = b.GetComponentsInChildren<Transform>();

                                        foreach (Transform cb in allChildren)
                                        {
                                            bz.MoveBlock(cb.GetComponent<BaseBlock>(), Vector3.back);
                                        }
                                    }

                                    break;

                                case Direction.RIGHT:
                                    b.SetBZSpace(Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().x + Vector3.right.x), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().y + Vector3.right.y), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().z + Vector3.right.z));

                                    if (InRange(b.GetBZSpace().GetBZSpace() + Vector3.right))
                                    {
                                        Transform[] allChildren = b.GetComponentsInChildren<Transform>();

                                        foreach (Transform cb in allChildren)
                                        {
                                            bz.MoveBlock(cb.GetComponent<BaseBlock>(), Vector3.right);
                                        }
                                    }

                                    break;

                                case Direction.LEFT:
                                    b.SetBZSpace(Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().x + Vector3.left.x), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().y + Vector3.left.y), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().z + Vector3.left.z));

                                    if (InRange(b.GetBZSpace().GetBZSpace() + Vector3.left))
                                    {
                                        Transform[] allChildren = b.GetComponentsInChildren<Transform>();

                                        foreach (Transform cb in allChildren)
                                        {
                                            bz.MoveBlock(cb.GetComponent<BaseBlock>(), Vector3.left);
                                        }
                                    }

                                    break;
                            }

                            b.SetPriority(7);
                            newRun[4] = true;
                            init[4] = true;
                        }
                    }

                    else
                    {
                        newRun[4] = true;
                    }
                }
            }
        }

        if (isActive[5] && isPowered)
        {
            if (InRange(GetBZSpace().GetBZSpace() + Vector3.down))
            {
                if (bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.down.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.down.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.down.z)] != null && bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.down.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.down.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.down.z)].transform.parent == null && bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.down.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.down.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.down.z)].tag != "StaticBlock" && bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.down.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.down.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.down.z)].tag != "SlideBlock" && bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.down.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.down.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.down.z)].tag != "RotateBlock")
                {
                    BaseBlock b = bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + Vector3.down.x), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + Vector3.down.y), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + Vector3.down.z)];

                    if (b.IsMaster(2) && b.GetCanStart())
                    {
                        if (newRun[5])
                        {
                            newRun[5] = false;
                            return;
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

                        if (InRange(target[5]))
                        {
                            if (bb[Mathf.RoundToInt(target[0].x - bz.transform.position.x), Mathf.RoundToInt(target[0].y - bz.transform.position.y), Mathf.RoundToInt(target[0].z - bz.transform.position.z)] == null || bb[Mathf.RoundToInt(target[0].x - bz.transform.position.x), Mathf.RoundToInt(target[0].y - bz.transform.position.y), Mathf.RoundToInt(target[0].z - bz.transform.position.z)].transform.IsChildOf(b.transform))
                            {
                                b.transform.position = Vector3.MoveTowards(b.transform.position, target[5], 1 * Time.deltaTime);
                            }
                        }

                        if (b.transform.position.x == target[5].x && b.transform.position.y == target[5].y && b.transform.position.z == target[5].z)
                        {
                            b.SetCanStart(false);

                            switch (dir[5])
                            {
                                case Direction.FORWARD:
                                    b.SetBZSpace(Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().x + Vector3.forward.x), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().y + Vector3.forward.y), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().z + Vector3.forward.z));

                                    if (InRange(b.GetBZSpace().GetBZSpace() + Vector3.forward))
                                    {
                                        Transform[] allChildren = b.GetComponentsInChildren<Transform>();

                                        foreach (Transform cb in allChildren)
                                        {
                                            bz.MoveBlock(cb.GetComponent<BaseBlock>(), Vector3.forward);
                                        }
                                    }

                                    break;

                                case Direction.BACK:
                                    b.SetBZSpace(Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().x + Vector3.back.x), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().y + Vector3.back.y), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().z + Vector3.back.z));

                                    if (InRange(b.GetBZSpace().GetBZSpace() + Vector3.back))
                                    {
                                        Transform[] allChildren = b.GetComponentsInChildren<Transform>();

                                        foreach (Transform cb in allChildren)
                                        {
                                            bz.MoveBlock(cb.GetComponent<BaseBlock>(), Vector3.back);
                                        }
                                    }

                                    break;

                                case Direction.RIGHT:
                                    b.SetBZSpace(Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().x + Vector3.right.x), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().y + Vector3.right.y), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().z + Vector3.right.z));

                                    if (InRange(b.GetBZSpace().GetBZSpace() + Vector3.right))
                                    {
                                        Transform[] allChildren = b.GetComponentsInChildren<Transform>();

                                        foreach (Transform cb in allChildren)
                                        {
                                            bz.MoveBlock(cb.GetComponent<BaseBlock>(), Vector3.right);
                                        }
                                    }

                                    break;

                                case Direction.LEFT:
                                    b.SetBZSpace(Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().x + Vector3.left.x), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().y + Vector3.left.y), Mathf.RoundToInt(b.GetBZSpace().GetBZSpace().z + Vector3.left.z));

                                    if (InRange(b.GetBZSpace().GetBZSpace() + Vector3.left))
                                    {
                                        Transform[] allChildren = b.GetComponentsInChildren<Transform>();

                                        foreach (Transform cb in allChildren)
                                        {
                                            bz.MoveBlock(cb.GetComponent<BaseBlock>(), Vector3.left);
                                        }
                                    }

                                    break;
                            }

                            b.SetPriority(7);
                            newRun[5] = true;
                            init[5] = true;
                        }
                    }

                    else
                    {
                        newRun[5] = true;
                    }
                }
            }
        }
    }
}