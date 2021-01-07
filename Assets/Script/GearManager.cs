
using System.Collections.Generic;
using UnityEngine;

public enum GearType
{
    None = 0,
    Active = 1,
    Text = 2,
    Toggle = 3,
}

public class GearManager : MonoBehaviour
{
    [SerializeField]
    Controller _controller;
    public Controller controller
    {
        get
        {
            return _controller;
        }
        set
        {
            if (_controller != value)
            {
                if (_controller) _controller.RemoveGearManager(this);
                _controller = value;
                if (_controller) _controller.AddGearManager(this);
            }
        }
    }

    [SerializeField]
    List<GearType> _gearTypes = new List<GearType>();

    #region
    [SerializeField]
    GearText gearText = new GearText();

    [SerializeField]
    GearActive gearActive = new GearActive();

    [SerializeField]
    GearToggle gearToggle = new GearToggle();

    #endregion

    public void UpdateGear()
    {
        for (int i = 0; i < _gearTypes.Count; i++)
        {
            GearType type = _gearTypes[i];
            if(GearType.None != type && controller != null)
            {
                IGear gear = GetGear(type);
                gear.UpdateState(controller.selectedIndex);
            }
        }
    }

    virtual public void HandleControllerChanged()
    {
        for (int i = 0; i < _gearTypes.Count; i++)
        {
            GearType type = _gearTypes[i];
            if (GearType.None != type && controller != null)
            {
                IGear gear = GetGear(type);
                gear.Apply(controller.selectedIndex);
            }
        }
    }


    public IGear GetGear(GearType type)
    {
        IGear gear = null;
        switch (type)
        {
            case GearType.Text:
                gear = gearText;
                break;
            case GearType.Active:
                gear = gearActive;
                break;
            case GearType.Toggle:
                gear = gearToggle;
                break;
            default:
                throw new System.Exception("invalid gear type!");
        }
        gear.Init_Root(gameObject);
        return gear;
    }

#if UNITY_EDITOR
    public List<GearType> GetGearTypes()
    {
        return _gearTypes;
    }

    public void AddGearType()
    {
        _gearTypes.Add(GearType.None);
    }

    public void AddGear(int index, GearType newType)
    {
        GearType oldType = _gearTypes[index];
        if (newType == oldType) return;
        if (GearType.None != newType && - 1 != this._gearTypes.IndexOf(newType)) return;
        _gearTypes[index] = newType;
        GetGear(newType);
    }

    public void removeGear(int index)
    {
        _gearTypes.RemoveAt(index);
    }

#endif
}
