using UnityEngine;
using System.Collections;

public class Spike : Variable
{
    void OnTriggerEnter(Collider _col)
    {
        if (_col.tag == "Enemy")
        {
            // Do hurt.
        }
    }
}