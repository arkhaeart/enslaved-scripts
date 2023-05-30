using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Items;
namespace GameSystems
{
    [CreateAssetMenu(menuName ="Settings/ItemDatabase")]

    public class ItemDatabase :ScriptableObject
    {
        const string itemsFolder = "Items";
        public List<Item> items = new List<Item>();
        public Dictionary<string, Item> itemDict = new Dictionary<string, Item>();
        public Dictionary<string, Armor> armorDict = new Dictionary<string, Armor>();
        public Dictionary<string, Weapon> weaponDict = new Dictionary<string, Weapon>();
        public Dictionary<string, Usable> usableDict = new Dictionary<string, Usable>();
        public Dictionary<string, Item> otherDict = new Dictionary<string, Item>();

        public void Init()
        {
            Load();
            Fill();
        }
        void Load()
        {
            items.Clear();
            var loaded = Resources.LoadAll(itemsFolder);
            foreach(var load in loaded)
            {
                items.Add(load as Item);
            }
        }
        void Fill()
        {
            foreach(var item in items)
            {
                if(!itemDict.ContainsKey(item.name))
                {
                    itemDict.Add(item.name, item);
                }
                if(!armorDict.ContainsKey(item.name)&&item is Armor armor)
                {
                    armorDict.Add(armor.name, armor);
                    continue;
                }
                else if (!weaponDict.ContainsKey(item.name) && item is Weapon weapon)
                {
                    weaponDict.Add(weapon.name, weapon);
                    continue;
                }
                else if(!usableDict.ContainsKey(item.name)&& item is Usable usable)
                {
                    usableDict.Add(usable.name, usable);
                    continue;
                }
                else if(!otherDict.ContainsKey(item.name))
                {
                    otherDict.Add(item.name, item);
                }
            }
        }
    }
}
