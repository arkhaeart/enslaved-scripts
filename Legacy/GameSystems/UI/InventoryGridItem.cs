using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Items;
namespace UI
{
    public class InventoryGridItem : UIMono
    {
        public int invIndex;
        public Item item;
        public InventoryGridCell cell;
        public void OnDrag(bool active)
        {
            SetInactive(active);

        }
        
    }
}