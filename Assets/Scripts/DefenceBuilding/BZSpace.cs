using UnityEngine;
using System.Collections;

public struct BZSpace
{
    private int x, y, z;

    public BZSpace(int _x, int _y, int _z)
    {
        x = _x;
        y = _y;
        z = _z;
    }

    public Vector3 GetBZSpace()
    {
        return new Vector3(x, y, z);
    }

    public void SetBZSpace(int _x, int _y, int _z)
    {
        x = _x;
        y = _y;
        z = _z;
    }
}