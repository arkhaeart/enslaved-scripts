using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Develop
{
    public class MonoAgentSkeleton : MonoBehaviour
    {
        [SerializeField] private Part[] parts;
        private Dictionary<string, SpriteRenderer> partsDict;
        
        private void InitDictionary()
        {
            partsDict = new Dictionary<string, SpriteRenderer>();
            foreach(var part in parts)
            {
                partsDict.TryAdd(part.equipmentSlot, part.spriteRenderer);
            }
        }
        public void SetSpriteToPart(string part, Sprite sprite)
        {
            if(partsDict==null)
            {
                InitDictionary();
            }
            if (partsDict.TryGetValue(part, out var renderer))
            {
                renderer.sprite = sprite;
            }
            else Debug.LogError($"Tried to set sprite to non-existent part {part} of {gameObject.name}");
        }
        [System.Serializable]
        public class Part
        {
            [StringDropDown(path = "Configs/EquipmentSlots")]
            public string equipmentSlot;
            public SpriteRenderer spriteRenderer;
        }
    }
    
}