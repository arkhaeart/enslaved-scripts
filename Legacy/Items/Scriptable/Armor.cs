using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Items
{
    [CreateAssetMenu(menuName = "Items/Armor")]
    [System.Serializable]
    public class Armor : Item, IEquipable
    {
        [field:Header("Slot Name")]
        [field: SerializeField]
        public string Slot { get; set; }
    }
}