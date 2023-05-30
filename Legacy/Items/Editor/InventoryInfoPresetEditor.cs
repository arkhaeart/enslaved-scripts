using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using GameSystems;
using Items;
[CustomEditor(typeof(InventoryInfoPreset))]
public class InventoryInfoPresetEditor : Editor
{
    const string itemDatabasePath = "";
    ItemDatabase Database
    {
        get => Resources.Load<ItemDatabase>(itemDatabasePath);
    }
    InventoryInfoPreset Obj
    {
        get => target as InventoryInfoPreset;
    }
    void OnItemChosenToInventory(object ID)
    {
        Obj.info.inventory.Add((string)ID);
    }
    void OnItemChosenToEquipment(object ID)
    {
        Obj.info.equipment.Add((string)ID);
    }
    void AddMenuItem(GenericMenu menu, string menuPath,string itemID,bool inventory)
    {
        if(inventory)
        {
            menu.AddItem(new GUIContent(menuPath), false, OnItemChosenToInventory, itemID);
        }
        else
        {
            menu.AddItem(new GUIContent(menuPath), false, OnItemChosenToEquipment, itemID);
        }
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        serializedObject.Update();
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Add to Inventory"))
        {
            GenericMenu menu = new GenericMenu();
            foreach (var weapon in Database.weaponDict)
            {
                AddMenuItem(menu, $"Weapons/{weapon.Key}", weapon.Key, true);
            }
            menu.AddSeparator("");
            foreach (var armor in Database.armorDict)
            {
                AddMenuItem(menu, $"Armors/{armor.Key}", armor.Key, true);
            }
            menu.AddSeparator("");
            foreach (var usable in Database.usableDict)
            {
                AddMenuItem(menu, $"Usables/{usable.Key}", usable.Key, true);
            }
            menu.AddSeparator("");
            foreach (var other in Database.otherDict)
            {
                AddMenuItem(menu, $"Other/{other.Key}", other.Key, true);
            }
            menu.ShowAsContext();
        }
        if (GUILayout.Button("Add to Equipment"))
        {
            GenericMenu menu = new GenericMenu();
            foreach(var weapon in Database.weaponDict)
            {
                AddMenuItem(menu, $"Weapons/{weapon.Key}", weapon.Key, false);
            }
            menu.AddSeparator("");
            foreach (var armor in Database.armorDict)
            {
                AddMenuItem(menu, $"Armors/{armor.Key}", armor.Key, false);
            }
            menu.ShowAsContext();
        }
        GUILayout.EndHorizontal();
        GUILayout.Space(20);
        GUILayout.BeginHorizontal();
        if(GUILayout.Button("Clear Inventory"))
        {
            Obj.info.inventory = new List<string>();
        }
        if(GUILayout.Button("Clear Equipment"))
        {
            Obj.info.equipment = new List<string>();
        }
        GUILayout.EndHorizontal();
        serializedObject.ApplyModifiedProperties();
        EditorUtility.SetDirty(target);
    }

}
