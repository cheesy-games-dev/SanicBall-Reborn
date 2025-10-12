using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Sanicball.Data;

[CustomPropertyDrawer(typeof(StageData))]
public class StageDataDrawer : PropertyDrawer
{
    // Draw the property inside the given rect
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
        // Using BeginProperty / EndProperty on the parent property means that
        // prefab override logic works on the entire property.
        EditorGUI.BeginProperty(position, label, property);

        // Draw label
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        // Don't make child fields be indented
        var indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        // Calculate rects
        var pictureRect = new Rect(position.x, position.y + 50, position.width, position.height);
        var nameRect = new Rect(position.x, position.y, 50, position.height);
        var idRect = new Rect(position.x + 35, position.y, 30, position.height);
        var sceneNameRect = new Rect(position.x + 90, position.y, position.width - 90, position.height);

        // Draw fields - pass GUIContent.none to each so they are drawn without labels
        EditorGUI.PropertyField(pictureRect, property.FindPropertyRelative("picture"), GUIContent.none);
        EditorGUI.PropertyField(nameRect, property.FindPropertyRelative("name"), GUIContent.none);
        EditorGUI.PropertyField(idRect, property.FindPropertyRelative("id"), GUIContent.none);
        EditorGUI.PropertyField(sceneNameRect, property.FindPropertyRelative("sceneName"), GUIContent.none);

        // Set indent back to what it was
        EditorGUI.indentLevel = indent;

        EditorGUI.EndProperty();
    }
}
