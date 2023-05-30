using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Items;
namespace Units.Modules {
    public class CharacterSkeletonModule :BehaviourModule
    {
        public Dictionary<string, SpriteRenderer> parts = new Dictionary<string, SpriteRenderer>();
        Dictionary<string, Item> slots;
        public CharacterSkeletonModule(Unit _mono) : base(_mono)
        {
            SpriteRenderer[] rends = mono.GetComponentsInChildren<SpriteRenderer>(true);
            foreach(var rend in rends)
            {
                parts.Add(rend.name, rend);
            }
        }
        // public void Init(EquipmentModule module)
        // {
        //     slots = module.slots;
        //     module.DrawCall += Draw;
        //     Draw();
        // }
        void Draw()
        {
            foreach(var slot in slots)
            {
                if(parts.ContainsKey(slot.Key))
                {
                    parts[slot.Key].sprite = slot.Value != null ? slot.Value.gameSprite : null;
                }
            }
        }
    }
}