using UnityEngine;
using System.Collections;

public class PowerNode : BaseBlock
{
    protected bool isPowered;
    protected bool[] stream = new bool[6] { true, true, true, true, true, true };
    
    public bool GetIsPowered() { return isPowered; }

    void Start()
    {
        isPowered = false;
    }

    public void State(bool _state)
    {
        isPowered = _state == true ? true : false;
        Debug.Log(isPowered);
    }
}