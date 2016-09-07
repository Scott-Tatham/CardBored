using UnityEngine;
using System.Collections;

public class BaseBlock : MonoBehaviour
{
    protected bool canStart;
    protected int priority;
    protected bool[] isActive = new bool[6] { true, true, true, true, true, true };
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
        canStart = false;
        priority = 7;
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
}