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
            EditorGUILayout.PropertyField(serializedObject.FindProperty("BulletP"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("BigSpell"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("BigForks"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("Flame"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("Impulsium"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("Smug"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("RainFire"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("BenedictioFenix"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("HellFlame"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("Hole"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("Dodge"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("BigSB"));
            ////////////////////////////////////////////////////////////////////
            EditorGUILayout.PropertyField(serializedObject.FindProperty("Skill_0"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("Skill_1"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("Skill_2"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("Skill_3"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("Skill_4"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("Skill_5"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("Skill_6"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("Skill_7"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("Skill_8"));
            ////////////////////////////////////////////////////////////////////
            EditorGUILayout.PropertyField(serializedObject.FindProperty("impronte"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("Foot"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("Rage"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("SkillPoint"));
            //EditorGUILayout.PropertyField(serializedObject.FindProperty("BPoint"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("CS"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("canImp"));
            // Add other fields as needed
        }
        if (myScript.knife)
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty("SlashV"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("SlashH"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("SlashB"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("BigSlash"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("Fury"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("DanceSwords"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("SlashBombing"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("RainSwords"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("SawTrain"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("Stalactites"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("Stump"));
            ////////////////////////////////////////////////////////////////////
            EditorGUILayout.PropertyField(serializedObject.FindProperty("Skill_0"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("Skill_1"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("Skill_2"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("Skill_3"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("Skill_4"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("Skill_5"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("Skill_6"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("Skill_7"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("Skill_8"));
            ////////////////////////////////////////////////////////////////////
            EditorGUILayout.PropertyField(serializedObject.FindProperty("impronte"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("Foot"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("Rage"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("SkillPoint"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("BPoint"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("CS"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("canImp"));
            // Add other fields as needed
        }
        if (myScript.spoon)
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty("isDefence"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("BenedictionTower"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("Cura"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("ShockWave"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("Shields"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("Explosion"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("HitStun"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("Revive"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("Reflect"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("ShiledB"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("ShiledT"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("Crush"));
            ////////////////////////////////////////////////////////////////////
            EditorGUILayout.PropertyField(serializedObject.FindProperty("Skill_0"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("Skill_1"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("Skill_2"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("Skill_3"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("Skill_4"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("Skill_5"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("Skill_6"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("Skill_7"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("Skill_8"));
            ////////////////////////////////////////////////////////////////////
            EditorGUILayout.PropertyField(serializedObject.FindProperty("impronte"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("Foot"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("Rage"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("SkillPoint"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("BPoint"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("CS"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("canImp"));
            // Add other fields as needed
        }
        if (myScript.Enemy)
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty("VfxEnmSlash"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("Bullet"));
            // Add other fields as needed
        }
        // Apply changes to serialized object
        serializedObject.ApplyModifiedProperties();
    }
}