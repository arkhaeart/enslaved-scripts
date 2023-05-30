using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSystems;
using Units.Modules;
namespace Items {
    public class InventoryInfoUtil
    {
        ItemDatabase itemDatabase;
        public InventoryInfoUtil(ItemDatabase itemDatabase)
        {
            this.itemDatabase = itemDatabase;
        }
        public void UnpackEquipment(InventoryInfo info, out Dictionary<string,Item> dict)
        {
            dict = new Dictionary<string, Item>();

            foreach(var ID in info.equipment)
            {
                Item item = itemDatabase.itemDict[ID];
                dict.Add(item.name,item);
            }
        }
        public void UnpackInventory(InventoryInfo info, out List<Item> list)
        {
            list = new List<Item>();

            foreach (var ID in info.inventory)
            {
                Item item = itemDatabase.itemDict[ID];
                list.Add(item);
            }
        }
        // public void UnpackAndInitInventoryInfo(InventoryInfo info, InventoryModule iModule,EquipmentModule eModule)
        // {
        //     UnpackInventory(info, out List< Item> idict);
        //     UnpackEquipment(info, out Dictionary<string, Item> edict);
        //     foreach(var item in idict)
        //     {
        //         iModule.AddItem(item, null);
        //     }
        //     foreach (var item in edict)
        //     {
        //         IEquipable equip = (IEquipable)item.Value;
        //         eModule.AddItem(item.Value, equip.Slot);
        //     }
        //
        // }
    }
}