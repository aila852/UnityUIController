using UnityEditor;
using UnityEditor.Experimental.SceneManagement;
using UnityEngine;

/// <summary>
/// 控制器监听器
/// </summary>
public class ControllerListener : EditorMonoBehaviour
{
    private bool _dirty = false;
    /// <summary>
    /// 当Hierarchy面板变化的时候，先设置为dirty
    /// </summary>
    public override void OnHierarchyWindowChanged()
    {
        if (Application.isPlaying)
        {
            return;
        }
        _dirty = true;
    }

    public override void Update()
    {
        if (_dirty)
        {
            _dirty = false;
            SaveProperties();//在下一次update的时候，进行保存属性
        }
    }

    private void SaveProperties()
    {
        Object activeObj = Selection.activeObject;
        if (activeObj == null)
        {
            return;
        }

        GameObject go = activeObj as GameObject;
        if (go == null)
        {
            return;
        }

        GearManager gearManager = go.GetComponent<GearManager>();
        if (gearManager)
        {
            gearManager.UpdateGear();
        }
    }

}