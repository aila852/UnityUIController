using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class GearToggle : GearBase<bool>
{
    protected override void Init()
    {
        _default = _owner.GetComponent<Toggle>() ? _owner.GetComponent<Toggle>().isOn : false;
    }

    override public void Apply(int index)
    {
        bool cv = Get(index);
        if (_owner.GetComponent<Toggle>())
        {
            _owner.GetComponent<Toggle>().isOn = cv;
        }
    }

    override public void UpdateState(int index)
    {
        if (_owner.GetComponent<Toggle>())
        {
            Set(index, _owner.GetComponent<Toggle>().isOn);
        }
    }
}
