using System.Collections.Generic;
using Develop.Items;
using Infrastructure.StateMachine.Scriptable;
using UnityEngine;

namespace Develop.Utilities
{
    public static class StringDropdownUtility
    {
        private const string EquipmentSlotsPath = "Configs/EquipmentSlots";
        private const string StateTypesPath = "Configs/StateTypes";
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

        public static List<string> GetStateTypes()
        {
            var typesConfig = Resources.Load<StateTypeToNameConfig>(StateTypesPath);
            List<string> slots = new List<string>() { "" };
            slots.AddRange(typesConfig.GetTypeNames());
            return slots;
        }
    }
}