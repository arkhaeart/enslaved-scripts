using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Develop.Items
{
    [CreateAssetMenu(menuName = "Scriptable/ItemData")]
    public class ItemData:SerializedScriptableObject
    {
        [TextArea]
        public string description;

        public int basePrice;
        public int size;
        public float quality;
        public ItemMaterial itemMaterial;
        [ValueDropdown("GetPrefabPaths")]
        public string prefabPath;
        [OdinSerialize]public IItemModule[] itemModules;
#if UNITY_EDITOR
        public List<string> GetPrefabPaths()
        {
            List<string> paths = new List<string>() { "" };
            paths.AddRange( UnityEditor.AssetDatabase.FindAssets("t:MonoItem"));
            return paths;
        }
#endif
    }
}