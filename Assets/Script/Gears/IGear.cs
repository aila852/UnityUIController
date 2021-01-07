using UnityEngine;
using UnityEditor;

public interface IGear
{
    void Init_Root(GameObject obj);
    void Dispose_Root();

    void Apply(int index);
    void UpdateState(int index);
}