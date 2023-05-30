using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
namespace Items
{

    public class ItemScriptable: ScriptableObject
    {
        public Item item;
        [MenuItem("Assets/CreateItemSO")]
        public static void CreateSO()
        {
            var SO = CreateInstance<ItemScriptable>();
            SO.item = new Weapon();
        }
    }
}