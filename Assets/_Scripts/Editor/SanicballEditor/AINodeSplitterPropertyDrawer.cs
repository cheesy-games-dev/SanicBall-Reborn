#if UNITY_EDITOR
using Sanicball;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(AINodeSplitterTarget))]
public class AINodeSplitterPropertyDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
        EditorGUI.BeginProperty(position, label, property);
        GUILayout.BeginHorizontal();
        EditorGUILayout.PropertyField(property.FindPropertyRelative("Weight"), GUIContent.none);
        EditorGUILayout.PropertyField(property.FindPropertyRelative("Node"), GUIContent.none);
        GUILayout.EndHorizontal();
        EditorGUI.EndProperty();
    }
}
#endif