using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using GameSystems;
namespace Containment
{
    [CustomEditor(typeof(Zone))]
    public class ZoneEditor : Editor
    {
        int index = 0;
        Zone obj
        {
            get=> target as Zone;
        }

        CrimeCodex codex => throw new System.NotImplementedException();
        
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            DrawDefaultInspector();
            
            index = EditorGUILayout.Popup(index, codex.crimeStrings);
            obj.crime = codex.crimeDict[codex.crimeStrings[index]].name;
            serializedObject.ApplyModifiedProperties();
        }
    }
}