using System.Collections.Generic;
using Develop.Utilities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Develop.Items.Configs
{
    [CreateAssetMenu(menuName = "Scriptable/Data/EquipmentMeshes")]
    public class EquipmentItemMeshData:ScriptableObject
    {
        public DataSet[] dataSets;
        [System.Serializable]
        public class DataSet
        {        
            [ValueDropdown("GetMeshSlots")]
            public string meshSlot;

            public Mesh skinnedMesh;
            public Mesh standaloneMesh;

            public List<string> GetMeshSlots()
            {
                return StringDropdownUtility.GetMeshSlots();
            }
        }
    }
}