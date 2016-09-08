using UnityEngine;
using System.Collections;

public class Transmit : PowerNode
{
    void TransmitF()
    {
        for (int i = 0; i < face.Length; i++)
        {
            if (face[i] != null && face[i].GetComponent<PowerNode>() != null)
            {
                if (face[i].GetComponent<PowerNode>().GetIsPowered())
                {
                    isPowered = true;
                }
            }
        }
    }
}
