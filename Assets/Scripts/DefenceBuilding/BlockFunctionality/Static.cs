using UnityEngine;
using System.Collections;

public class Static : BaseBlock
{
    protected override void Start()
    {
        for (int i = 0; i < 6; i++)
        {
            GetComponent<BoxUVs>().SetSide(i, BoxUVs.Side.STATIC);
        }
    }
}