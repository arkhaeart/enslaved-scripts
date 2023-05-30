using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
namespace GameSystems.GameEvent
{
    [CustomEditor(typeof(TestEventManager))]
    public class TestEventEditor : Editor
    {
        TestEventManager obj
        {
            get => target as TestEventManager;
        }
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            if(GUILayout.Button("Set Player a criminal"))
            {
                obj.Criminal();
            }
        }
    }
}