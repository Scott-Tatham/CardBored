using UnityEngine;
using System.Collections;

public class BaseBlock : MonoBehaviour
{
    protected bool canStart;
    protected int priority;
    protected bool[] isActive = new bool[6] { true, true, true, true, true, true };
    protected BaseBlock[] face = new BaseBlock[6];
    protected BaseBlock[,,] bb;
    protected BZSpace bzSpace;
    protected BoundingBox bz;
    protected EventTimer et;
    
    public bool GetCanStart() { return canStart; }
    public int GetPriority() { return priority; }
    public BZSpace GetBZSpace() { return bzSpace; }
    
    public void SetCanStart(bool _canStart) { canStart = _canStart; }
    public void SetPriority(int _priority) { priority = _priority; }
    public void SetBZSpace(int _x, int _y, int _z) { bzSpace = new BZSpace(_x, _y, _z); }

    protected virtual void Awake()
    {
        et = GameObject.FindGameObjectWithTag("GameManager").GetComponent<EventTimer>();
    }

    protected virtual void Start()
    {
        canStart = false;
        priority = 7;

        for (int i = 0; i < 6; i++)
        {
            GetComponent<BoxUVs>().SetSide(i, BoxUVs.Side.EMPTY);
        }
    }

    protected virtual void Update()
    {
        if (!et.GetCanDo())
        {
            canStart = true;
        }
    }

    public void SetBounds(BoundingBox _b)
    {
        bz = _b;
        bb = _b.GetBlocks();
    }

    protected bool InRange(Vector3 _pos)
    {
        if (_pos.x >= bz.transform.position.x && _pos.x < bz.GetBounds().x + bz.transform.position.x && _pos.y >= bz.transform.position.y && _pos.y < bz.GetBounds().y + bz.transform.position.y && _pos.z >= bz.transform.position.z && _pos.z < bz.GetBounds().z + bz.transform.position.z)
        {
            return true;
        }

        return false;
    }

    public bool IsMaster(int _priority)
    {
        if (_priority <= priority)
        {
            priority = _priority;
            return true;
        }

        return false;
    }

    protected void SetFace(int _multi = 1)
    {
        if (InRange(GetBZSpace().GetBZSpace() + (Vector3.forward * _multi)))
        {
            if (bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + (Vector3.forward.x * _multi)), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + (Vector3.forward.y * _multi)), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + (Vector3.forward.z * _multi))] != null)
            {
                face[0] = bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + (Vector3.forward.x * _multi)), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + (Vector3.forward.y * _multi)), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + (Vector3.forward.z * _multi))];
            }

            else
            {
                face[0] = null;
            }
        }

        else
        {
            face[0] = null;
        }

        if (InRange(GetBZSpace().GetBZSpace() + (Vector3.back * _multi)))
        {
            if (bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + (Vector3.back.x * _multi)), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + (Vector3.back.y * _multi)), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + (Vector3.back.z * _multi))] != null)
            {
                face[1] = bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + (Vector3.back.x * _multi)), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + (Vector3.back.y * _multi)), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + (Vector3.back.z * _multi))];
            }

            else
            {
                face[1] = null;
            }
        }

        else
        {
            face[1] = null;
        }

        if (InRange(GetBZSpace().GetBZSpace() + (Vector3.right * _multi)))
        {
            if (bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + (Vector3.right.x * _multi)), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + (Vector3.right.y * _multi)), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + (Vector3.right.z * _multi))] != null)
            {
                face[2] = bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + (Vector3.right.x * _multi)), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + (Vector3.right.y * _multi)), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + (Vector3.right.z * _multi))];
            }

            else
            {
                face[2] = null;
            }
        }

        else
        {
            face[2] = null;
        }

        if (InRange(GetBZSpace().GetBZSpace() + (Vector3.left * _multi)))
        {
            if (bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + (Vector3.left.x * _multi)), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + (Vector3.left.y * _multi)), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + (Vector3.left.z * _multi))] != null)
            {
                face[3] = bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + (Vector3.left.x * _multi)), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + (Vector3.left.y * _multi)), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + (Vector3.left.z * _multi))];
            }

            else
            {
                face[3] = null;
            }
        }

        else
        {
            face[3] = null;
        }

        if (InRange(GetBZSpace().GetBZSpace() + (Vector3.up * _multi)))
        {
            if (bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + (Vector3.up.x * _multi)), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + (Vector3.up.y * _multi)), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + (Vector3.up.z * _multi))] != null)
            {
                face[4] = bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + (Vector3.up.x * _multi)), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + (Vector3.up.y * _multi)), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + (Vector3.up.z * _multi))];
            }

            else
            {
                face[4] = null;
            }
        }

        else
        {
            face[4] = null;
        }

        if (InRange(GetBZSpace().GetBZSpace() + (Vector3.down * _multi)))
        {
            if (bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + (Vector3.down.x * _multi)), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + (Vector3.down.y * _multi)), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + (Vector3.down.z * _multi))] != null)
            {
                face[5] = bb[Mathf.RoundToInt(GetBZSpace().GetBZSpace().x + (Vector3.down.x * _multi)), Mathf.RoundToInt(GetBZSpace().GetBZSpace().y + (Vector3.down.y * _multi)), Mathf.RoundToInt(GetBZSpace().GetBZSpace().z + (Vector3.down.z * _multi))];
            }

            else
            {
                face[5] = null;
            }
        }

        else
        {
            face[5] = null;
        }
    }

    public void RemoveBlock()
    {
        bz.RemoveBlock(this);
    }
}