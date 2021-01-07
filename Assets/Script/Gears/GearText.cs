using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class GearText : GearBase<string>
{
    protected override void Init()
    {
        _default = _owner.GetComponent<Text>() ? _owner.GetComponent<Text>().text : "";
    }

    override public void Apply(int index)
    {
        string cv = Get(index);
        if (_owner.GetComponent<Text>())
        {
            _owner.GetComponent<Text>().text = cv;
        }
    }

    override public void UpdateState(int index)
    {
        if (_owner.GetComponent<Text>())
        {
            Set(index, _owner.GetComponent<Text>().text);
        }
    }
}
