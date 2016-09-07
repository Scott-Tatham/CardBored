using UnityEngine;
using System.Collections;

public class Variable : BaseBlock
{
    int parentCount;

    public int GetParentCount() { return parentCount; }

    public void SetParent(Transform _parent)
    {
        if (_parent.GetComponent<Variable>().GetParentCount() < 3)
        {
            transform.SetParent(_parent);
            parentCount = _parent.GetComponent<Variable>().GetParentCount() + 1;
        }
    }
}