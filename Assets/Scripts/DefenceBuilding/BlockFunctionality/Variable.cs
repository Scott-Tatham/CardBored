using UnityEngine;
using System.Collections;

public class Variable : BaseBlock
{
    [SerializeField]
    int maxChildCount;
    int parentCount;

    public int GetParentCount() { return parentCount; }

    public void SetParent(Transform _parent)
    {
        if (_parent.GetComponent<Variable>().GetParentCount() < maxChildCount)
        {
            transform.SetParent(_parent);
            parentCount = _parent.GetComponent<Variable>().GetParentCount() + 1;
            transform.rotation = transform.parent.rotation;
        }
    }

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();
        
        GetComponent<BoxUVs>().SetSide(0, BoxUVs.Side.EMPTY);
        GetComponent<BoxUVs>().SetSide(1, BoxUVs.Side.TAPE);
        GetComponent<BoxUVs>().SetSide(2, BoxUVs.Side.EMPTY);
        GetComponent<BoxUVs>().SetSide(3, BoxUVs.Side.EMPTY);
        GetComponent<BoxUVs>().SetSide(4, BoxUVs.Side.LETTUCEL);
        GetComponent<BoxUVs>().SetSide(5, BoxUVs.Side.LETTUCEL);
    }
}