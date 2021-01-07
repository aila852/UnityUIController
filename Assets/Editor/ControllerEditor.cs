using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

[CustomEditor(typeof(Controller))]
public class ControllerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();
        Controller controller = (Controller)target;

        List<string> pageIds = controller.GetPageIds();

        if (GUILayout.Button("+"))
        {
            controller.AddPage();
        }

        if (0 < pageIds.Count)
        {
            if (GUILayout.Button("-"))
            {
                controller.RemovePage();
            }
        }

        for (int i = 0; i < pageIds.Count; i++)
        {
            CreateStateValue(controller, i, pageIds[i]);
        }
    }

    /// <summary>
    /// 添加控制器状态
    /// </summary>
    /// <param name="conObj"></param>
    /// <param name="valueIndex"></param>
    /// <param name="value"></param>
    private void CreateStateValue(Controller conObj, int valueIndex, string value)
    {
        EditorGUILayout.BeginHorizontal();

        if (conObj.selectedIndex == valueIndex)
        {
            GUILayout.Label("✔", GUILayout.Width(100));
        }
        else
        {
            if (GUILayout.Button("选定", GUILayout.Width(100)))
            {
                conObj.selectedIndex= valueIndex;
            }
        }
        GUILayout.Label(valueIndex.ToString(), GUILayout.Width(50));

        string newValue = EditorGUILayout.TextField(value);
        if (!string.IsNullOrEmpty(newValue) && value != newValue)
        {
            conObj.ChangePageName(valueIndex, newValue);
        }

        EditorGUILayout.EndHorizontal();
    }
}