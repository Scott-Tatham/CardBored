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
        DOWN
    }

    private Direction[] dir = new Direction[6]
    {
        Direction.RIGHT,
        Direction.LEFT,
        Direction.BACK,
        Direction.FORWARD,
        Direction.RIGHT,
        Direction.LEFT
    };

    private EventTimer et;

    void Awake()
    {
        et = GameObject.FindGameObjectWithTag("GameManager").GetComponent<EventTimer>();
    }

    void Update()
    {
        if (et.GetCanDo())
        {
            SlideF();
        }
    }

    void SlideF()
    {
        foreach (Transform t in GetComponentInChildren<Transform>())
        {
            switch (t.GetComponent<BaseBlock>().GetSide())
            {
                case Sides.NORTH:
                    switch (dir[0])
                    {
                        case Direction.RIGHT:
                            t.position = Vector3.MoveTowards(t.position, t.position + Vector3.right, 1 * Time.deltaTime);
                            break;

                        case Direction.LEFT:
                            t.position = Vector3.MoveTowards(t.position, t.position + Vector3.left, 1 * Time.deltaTime);
                            break;

                        case Direction.UP:
                            t.position = Vector3.MoveTowards(t.position, t.position + Vector3.up, 1 * Time.deltaTime);
                            break;

                        case Direction.DOWN:
                            t.position = Vector3.MoveTowards(t.position, t.position + Vector3.down, 1 * Time.deltaTime);
                            break;
                    }

                    
                    break;

                case Sides.SOUTH:
                    switch (dir[1])
                    {
                        case Direction.RIGHT:
                            t.position = Vector3.MoveTowards(t.position, t.position + Vector3.right, 1 * Time.deltaTime);
                            break;

                        case Direction.LEFT:
                            t.position = Vector3.MoveTowards(t.position, t.position + Vector3.left, 1 * Time.deltaTime);
                            break;

                        case Direction.UP:
                            t.position = Vector3.MoveTowards(t.position, t.position + Vector3.up, 1 * Time.deltaTime);
                            break;

                        case Direction.DOWN:
                            t.position = Vector3.MoveTowards(t.position, t.position + Vector3.down, 1 * Time.deltaTime);
                            break;
                    }
                    break;

                case Sides.EAST:
                    switch (dir[2])
                    {
                        case Direction.FORWARD:
                            t.position = Vector3.MoveTowards(t.position, t.position + Vector3.forward, 1 * Time.deltaTime);
                            break;

                        case Direction.BACK:
                            t.position = Vector3.MoveTowards(t.position, t.position + Vector3.back, 1 * Time.deltaTime);
                            break;

                        case Direction.UP:
                            t.position = Vector3.MoveTowards(t.position, t.position + Vector3.up, 1 * Time.deltaTime);
                            break;

                        case Direction.DOWN:
                            t.position = Vector3.MoveTowards(t.position, t.position + Vector3.down, 1 * Time.deltaTime);
                            break;
                    }
                    break;

                case Sides.WEST:
                    switch (dir[3])
                    {
                        case Direction.FORWARD:
                            t.position = Vector3.MoveTowards(t.position, t.position + Vector3.forward, 1 * Time.deltaTime);
                            break;

                        case Direction.BACK:
                            t.position = Vector3.MoveTowards(t.position, t.position + Vector3.back, 1 * Time.deltaTime);
                            break;

                        case Direction.UP:
                            t.position = Vector3.MoveTowards(t.position, t.position + Vector3.up, 1 * Time.deltaTime);
                            break;

                        case Direction.DOWN:
                            t.position = Vector3.MoveTowards(t.position, t.position + Vector3.down, 1 * Time.deltaTime);
                            break;
                    }
                    break;

                case Sides.TOP:
                    switch (dir[4])
                    {
                        case Direction.FORWARD:
                            t.position = Vector3.MoveTowards(t.position, t.position + Vector3.forward, 1 * Time.deltaTime);
                            break;

                        case Direction.BACK:
                            t.position = Vector3.MoveTowards(t.position, t.position + Vector3.back, 1 * Time.deltaTime);
                            break;

                        case Direction.RIGHT:
                            t.position = Vector3.MoveTowards(t.position, t.position + Vector3.right, 1 * Time.deltaTime);
                            break;

                        case Direction.LEFT:
                            t.position = Vector3.MoveTowards(t.position, t.position + Vector3.left, 1 * Time.deltaTime);
                            break;
                    }
                    break;

                case Sides.BOTTOM:
                    switch (dir[5])
                    {
                        case Direction.FORWARD:
                            t.position = Vector3.MoveTowards(t.position, t.position + Vector3.forward, 1 * Time.deltaTime);
                            break;

                        case Direction.BACK:
                            t.position = Vector3.MoveTowards(t.position, t.position + Vector3.back, 1 * Time.deltaTime);
                            break;

                        case Direction.RIGHT:
                            t.position = Vector3.MoveTowards(t.position, t.position + Vector3.right, 1 * Time.deltaTime);
                            break;

                        case Direction.LEFT:
                            t.position = Vector3.MoveTowards(t.position, t.position + Vector3.left, 1 * Time.deltaTime);
                            break;
                    }
                    break;
            }
            //t.Reparent(t.position + );
        }
    }
}