using System.Collections.Generic;
using Develop.Items;
using UnityEngine;

namespace Develop.Utilities
{
    public static class StringDropdownUtility
    {
        private const string EquipmentSlotsPath = "Configs/EquipmentSlots";
        public static List<string> GetMeshSlots()
        {
            var slotsConfig = Resources.Load<EquipmentSlotsConfig>(EquipmentSlotsPath);
            List<string> slots = new List<string>() { "" };
            slots.AddRange(slotsConfig.meshSlots);
            return slots;
        }
        public static List<string> GetEquipmentSlots()
        {
            var slotsConfig = Resources.Load<EquipmentSlotsConfig>(EquipmentSlotsPath);
            List<string> slots = new List<string>() { "" };
            slots.AddRange(slotsConfig.equipmentSlots);
            return slots;
        }
    }
}