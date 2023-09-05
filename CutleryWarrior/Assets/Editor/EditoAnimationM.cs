using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(AnimationManager))]
public class EditoAnimationM : Editor
{
    public override void OnInspectorGUI()
    {
        AnimationManager myScript = (AnimationManager)target;
        // Draw default fields
        DrawDefaultInspector();

        // Check the condition and show additional fields
        if (myScript.fork)
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty("Bullet"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("BPoint"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("BigSpell"));
            // Add other fields as needed
        }
        if (myScript.knife)
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty("SlashV"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("SlashH"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("SlashB"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("Increase"));
            // Add other fields as needed
        }
        if (myScript.spoon)
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty("isDefence"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("Cura"));
            // Add other fields as needed
        }
        // Apply changes to serialized object
        serializedObject.ApplyModifiedProperties();
    }
}