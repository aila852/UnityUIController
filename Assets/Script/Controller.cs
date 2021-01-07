using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Controller : MonoBehaviour
{

    [SerializeField]
    int _selectedIndex;

    [SerializeField]
    List<string> _pageIds = new List<string>();

    [SerializeField]
    List<GearManager> gearManagers = new List<GearManager>();

    int _previousIndex;

    public void Awake()
    {
        _previousIndex = _selectedIndex;
    }

    public bool AddGearManager(GearManager value)
    {
        if (value && -1 == gearManagers.IndexOf(value))
        {
            gearManagers.Add(value);
            return true;
        }
        return false;
    }

    public bool RemoveGearManager(GearManager value)
    {
        if (value && -1 != gearManagers.IndexOf(value))
        {
            gearManagers.Remove(value);
            return true;
        }
        return false;
    }

    /// <summary>
    /// Current page index.
    /// 获得或设置当前活动页面索引。
    /// </summary>
    public int selectedIndex
    {
        get
        {
            return _selectedIndex;
        }
        set
        {
            if (_selectedIndex != value)
            {
                if (value > _pageIds.Count - 1)
                {
                    throw new IndexOutOfRangeException("" + value);
                }
                    
                _previousIndex = _selectedIndex;
                _selectedIndex = value;

                int cnt = gearManagers.Count;
                for (int i = 0; i < cnt; ++i)
                {
                    GearManager gearM = gearManagers[i];
                    if(gearM) gearM.HandleControllerChanged();
                }

                //DispatchEvent("onChanged", null);
            }
        }
    }

    public string selectedPageId
    {
        get
        {
            if (_selectedIndex == -1)
                return string.Empty;
            else
                return _pageIds[_selectedIndex];
        }
        set
        {
            int i = _pageIds.IndexOf(value);
            if (i != -1)
                this.selectedIndex = i;
        }
    }

#if UNITY_EDITOR
    public List<string> GetPageIds()
    {
        return this._pageIds;
    }

    public void AddPage(string value = null)
    {
        if(null != value)
            this._pageIds.Add(value);
        else
            this._pageIds.Add("" + this._pageIds.Count);
    }

    public void RemovePage()
    {
        if (0 < this._pageIds.Count)
        {
            this._pageIds.RemoveAt(this._pageIds.Count - 1);
            if (this._pageIds.Count <= selectedIndex)
            {
                selectedIndex = this._pageIds.Count - 1;
            }
        }
    }

    public void ChangePageName(int valueIndex, string newVal)
    {
        this._pageIds[valueIndex] = newVal;
    }
#endif
}
