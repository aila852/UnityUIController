using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class GearActive : GearBase<bool>
{
    public void Init_Root(GameObject obj)
    {
        
    }

    protected override void Init()
    {
        _default = true;
    }

    override public void Apply(int index)
    {
        bool cv = Get(index);
        _owner.SetActive(cv);
    }

    override public void UpdateState(int index)
    {
        Set(index, _owner.activeSelf);
    }
}
