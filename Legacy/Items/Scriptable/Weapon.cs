using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Items
{
    [CreateAssetMenu(menuName = "Items/Weapon")]
    [System.Serializable]
    public class Weapon : Item,IEquipable
    {
        public WeaponType type;
        public float rawDamage;
        
        [field: Header("Slot Name")]
        [field: SerializeField]
        public string Slot { get; set; }
    }
    public enum WeaponType
    {
        CUT,
        PIERCE,
        BLUNT,
        SHOOT
    }
}