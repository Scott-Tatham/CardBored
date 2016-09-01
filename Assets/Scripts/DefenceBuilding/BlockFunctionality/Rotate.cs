using UnityEngine;
using System.Collections;

public class Rotate : BaseBlock
{
    // Todo - Direction and side options.
    protected override void Update()
    {
        base.Update();

        RotateF();
    }

    void RotateF()
    {
        foreach (Transform t in GetComponentInChildren<Transform>())
        {
            t.RotateAround(transform.position, (t.position - transform.position).normalized, 1.0f);
        }
    }
}
