using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Items
{
    [CreateAssetMenu(menuName ="Items/WorkShopReaction")]
    public class WorkShopReaction : ScriptableObject
    {
        public string requiredWorkshop;
        public List<string> requiredItems;
        //Other requirements
        public float time;
        public string resultedItem;
    }
}