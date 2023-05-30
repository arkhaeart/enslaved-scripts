using Sirenix.OdinInspector;

namespace Develop.Items
{
    [System.Serializable]
    public class EquipableModule
    {
        [ValueDropdown("@StringDropdownUtility.GetEquipmentSlots")]
        public string slot;
        public int coverage;
        public float thickness;
        public MeshPath[] meshPaths;
    }

    [System.Serializable]
    public class MeshPath
    {
        public GenderUsage genderUsage;
        public string path;
    }
    
}