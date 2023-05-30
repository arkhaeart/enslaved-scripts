#if(UNITY_EDITOR)
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
[CustomPropertyDrawer(typeof(TypeStringDropDownAttribute))]
public class DropDownAttributeEditor : PropertyDrawer
{
    TypeStringDropDownAttribute typeAttribute => attribute as TypeStringDropDownAttribute;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        //property.serializedObject.Update();

        string current = property.stringValue;
        Rect rect1, rect2;
        rect1 = new Rect(position.x, position.y, position.width / 2, position.height);
        rect2 = new Rect(position.x + position.width / 2, position.y, position.width / 2, position.height);
        EditorGUI.PropertyField(rect1, property, new GUIContent());
        if (EditorGUI.DropdownButton(rect2, new GUIContent("Choose item"), FocusType.Passive))
        {
            GenericMenu menu = new GenericMenu();
            var types = NamespaceClassesUtility.GetTypes(typeAttribute.namespaceName);

            foreach (var type in types)
            {
                string name = type.ToString();
                AddMenuItem(menu, name, name == current, property);
            }
            menu.ShowAsContext();

        }

        //property.serializedObject.ApplyModifiedProperties();

        //base.OnGUI(position, property, label);
    }
    void ItemSelected(object arg, SerializedProperty property)
    {
        property.stringValue = (string)arg;
        property.serializedObject.ApplyModifiedProperties();
    }
    void AddMenuItem(GenericMenu menu, string id, bool on, SerializedProperty property)
    {
        menu.AddItem(new GUIContent(id), on, (arg) => ItemSelected(arg, property), id);
    }

}
#endif