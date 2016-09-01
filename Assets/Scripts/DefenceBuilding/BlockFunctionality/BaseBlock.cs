using UnityEngine;
using System.Collections;

public class BaseBlock : MonoBehaviour
{
    protected bool canStart;
    protected bool[] isActive = new bool[6] { true, true, true, true, true, true };
    protected bool[] init = new bool[6] { true, true, true, true, true, true };
    protected bool[] late = new bool[6];
    protected BaseBlock[,,] bb;
    protected BZSpace bzSpace;
    protected BoundingBox bz;
    protected EventTimer et;
    
    public bool GetCanStart() { return canStart; }
    public BZSpace GetBZSpace() { return bzSpace; }

    public void SetBZSpace(int _x, int _y, int _z) { bzSpace = new BZSpace(_x, _y, _z); }

    protected virtual void Awake()
    {
        et = GameObject.FindGameObjectWithTag("GameManager").GetComponent<EventTimer>();
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
        if (_pos.x >= 0 && _pos.x < bz.GetBounds().x && _pos.y >= 0 && _pos.y < bz.GetBounds().y && _pos.z >= 0 && _pos.z < bz.GetBounds().z)
        {
            return true;
        }

        return false;
    }
}