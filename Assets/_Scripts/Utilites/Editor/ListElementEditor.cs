using System;
using UnityEditor;
using UnityEngine;
using World2D.Generator.Noise;

namespace World2D
{
 
    public class ListElementEditor : Editor
    {
        //SerializedProperty listProperty;

        //void OnEnable()
        //{
        //    listProperty = serializedObject.FindProperty("_landBiomeModel");
        //}

        //public override void OnInspectorGUI()
        //{
        //    serializedObject.Update();

        //    EditorGUILayout.PropertyField(listProperty, true);

        //    if (listProperty.isExpanded)
        //    {
        //        EditorGUI.indentLevel++;
        //        for (int i = 0; i < listProperty.arraySize; i++)
        //        {
        //            SerializedProperty element = listProperty.GetArrayElementAtIndex(i);
        //            EditorGUILayout.PropertyField(element, new GUIContent("Elementssss " + i), true);
        //        }
        //        EditorGUI.indentLevel--;
        //    }

        //    serializedObject.ApplyModifiedProperties();
        //}
    }
}
