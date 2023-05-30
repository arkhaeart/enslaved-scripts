using UnityEngine;
using UnityEngine.Serialization;

namespace Develop.Items.Configs
{
    public class ItemSizeToUsageConfig:ScriptableObject
    {
        
    }

    [System.Serializable]
    public class ItemToSizeUsageEntry
    {
        public int minSize;
        public int maxSize;
        public int minWeight;
        public int maxWeight;
        public ItemAllowedUsage itemAllowedUsage;
    }
}