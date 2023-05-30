using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Develop.Items
{
    [System.Serializable]
    [CreateAssetMenu(menuName = "Configs/EquipmentSlots")]
    public class EquipmentSlotsConfig : ScriptableObject
    {
        [FormerlySerializedAs("possibleSlots")] public string[] meshSlots;
        public string[] equipmentSlots;

        
    }
}