using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Items {
    public interface IEquipable
    {
        string name { get; set; }
        string Slot { get; set; }
    }
    [CreateAssetMenu(menuName ="Items/Item")]
    [System.Serializable]
    public class Item:ScriptableObject
    {

        public Sprite gameSprite,uiSprite;
        //public GameObject prefab;
        public int value;
        public float weight;
        [Header("Inventory Dimensions")]
        public int X;
        public int Y;
        [Space(20)]
        public ItemMaterial material;
        
        
        [HideInInspector]public List<WorkShopReaction> reactions;
    }
    public enum ItemMaterial
    {
        DEFAULT,
        WOOD,
        CLOTH,
        LEATHER,
        STONE,
        BONE,
        COPPER,
        BRONZE,
        IRON
    }
}