using UnityEngine;

namespace Develop.Items.Configs
{
    [CreateAssetMenu(menuName = "Scriptable/Config/MaterialStats")]
    public class MaterialStatsConfig:ScriptableObject
    {
        public MaterialStatsEntry[] materialStatsEntries;
    }

    [System.Serializable]
    public class MaterialStatsEntry
    {
        public ItemMaterial itemMaterial;
        public float density;
        
    }
}