using UnityEngine;
using System.Collections;

public class BaseBlock : MonoBehaviour
{
    public enum Sides
    {
        NORTH,
        SOUTH,
        EAST,
        WEST,
        TOP,
        BOTTOM
    }

    protected bool[] isActive = new bool[6] { true, true, true, true, true, true };
    protected BZSpace bzSpace;
    protected Sides side;



    public BZSpace GetBZSpace() { return bzSpace; }
    public Sides GetSide() { return side; }

    public void SetBZSpace(int _x, int _y, int _z) { bzSpace = new BZSpace(_x, _y, _z); }
    public void SetSide(Vector3 _pos)
    {
        if (_pos == Vector3.forward)
        {
            side = Sides.NORTH;
        }

        else if (_pos == Vector3.back)
        {
            side = Sides.SOUTH;
        }

        else if (_pos == Vector3.right)
        {
            side = Sides.EAST;
        }

        else if (_pos == Vector3.left)
        {
            side = Sides.WEST;
        }

        else if (_pos == Vector3.up)
        {
            side = Sides.TOP;
        }

        else
        {
            side = Sides.BOTTOM;
        }
    }

    public void SetBlockParent(Transform _parent)
    {
        transform.SetParent(_parent);
        transform.rotation = transform.parent.rotation;
    }

    public void Reparent(Sides _side, BZSpace _bzSpace)
    {
        bzSpace = _bzSpace;

        switch (_side)
        {
            // Set zone so I can make Contains cheaper and to be able simply iterate through the available BZSpaces.
            // Is there a better way to find an object at a point? Oh 3D Array. Duh.-
            case Sides.NORTH:
                //transform.SetParent();
                break;

            case Sides.SOUTH:

                break;

            case Sides.EAST:

                break;

            case Sides.WEST:

                break;

            case Sides.TOP:

                break;

            case Sides.BOTTOM:

                break;
        }
    }
}
