using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

[CustomEditor(typeof(GearManager))]
public class GearManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();
        GearManager gearManager = (GearManager)target;

        gearManager.controller = (Controller)EditorGUILayout.ObjectField("Controller", gearManager.controller, typeof(Controller), true);

        if (null != gearManager.controller)
        {
            List<string> pageIds = gearManager.controller.GetPageIds();
            gearManager.controller.selectedIndex = GUILayout.Toolbar(gearManager.controller.selectedIndex, pageIds.ToArray());


            List<GearType> gearTypes = gearManager.GetGearTypes();


            for (int i = 0; i < gearTypes.Count; i++)
            {
                CreateGear(gearManager, i, gearTypes[i]);
            }

            if (GUILayout.Button("+"))
            {
                gearManager.AddGearType();
            }
        }



    }

    //添加Gear
    private void CreateGear(GearManager manager, int valueIndex, GearType value)
    {
        EditorGUILayout.BeginHorizontal();
        GearType popuptype = (GearType)EditorGUILayout.EnumPopup("options", value);
        if (value != popuptype)
        {
            manager.AddGear(valueIndex, popuptype);
        }
        if (GUILayout.Button("X", GUILayout.Width(50)))
        {
            manager.removeGear(valueIndex);
        }
        EditorGUILayout.EndHorizontal();

    }

}