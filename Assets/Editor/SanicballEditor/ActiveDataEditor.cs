using UnityEngine;
using UnityEditor;
using Sanicball.Data;
using Newtonsoft.Json;


[CustomEditor(typeof(ActiveData))]
public class ActiveDataEditor : Editor
{
    static string DynamicDatas;

    public override void OnInspectorGUI()
    {
        try
        {
            DynamicDatas = JsonConvert.SerializeObject(ActiveData.singleton.dynamicDatas, Formatting.Indented);
        }
        catch
        {
            
        }
        base.OnInspectorGUI();
        EditorGUI.BeginDisabledGroup(true);
        TextArea("Dynamic Datas", DynamicDatas);
        EditorGUI.EndDisabledGroup();
    }

    public static void TextArea(string label, string content, int pixels = 5, bool containColon = true)
    {
        if (containColon) label += ":";
        GUILayout.Label(label);
        EditorGUILayout.TextArea(content);
        GUILayout.Space(pixels);
    }

}
