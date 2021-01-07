using UnityEngine;
using System.Collections.Generic;
using System;

[Serializable]
public abstract class GearBase<T> : IGear
{
    [SerializeField]
    protected bool _isInit;
    [SerializeField]
    protected GameObject _owner;


    [SerializeField]
    private List<int> _storageIndex = new List<int>();
    [SerializeField]
    private List<T> _storage = new List<T>();

    [SerializeField]
    protected T _default;

    public void Init_Root(GameObject obj)
    {
        if (!_isInit)
        {
            _isInit = true;
            _owner = obj;
            Init();
        }
    }

    public void Dispose_Root()
    {
        if (_isInit)
        {
            _isInit = false;
            Dispose();
        }
    }

    // set storage
    protected void Set(int index, T value)
    {
        int i = _storageIndex.IndexOf(index);
        if (-1 == i)
        {
            _storageIndex.Add(index);
            _storage.Add(value);
        }
        else
        {
            _storage[i] = value;
        }

    }

    // get stroaget
    protected T Get(int index)
    {
        int i = _storageIndex.IndexOf(index);
        if (-1 != i)
        {
            return _storage[i];
        }
        return _default;
    }

    //init
    abstract protected void Init();

    //dispose
    virtual protected void Dispose() { }

    //Call when controller active page changed.
    abstract public void Apply(int index);

    //Call when object's properties changed.
    abstract public void UpdateState(int index);
}
