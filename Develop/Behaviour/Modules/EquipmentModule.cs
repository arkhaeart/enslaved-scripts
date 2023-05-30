// using System.Collections;
// using System.Collections.Generic;
// using Develop.Behaviour;
// using UnityEngine;
// using Units;
// using Items;
// using GameSystems;
// namespace Units.Modules
// {
//     public class EquipmentModule : 
//     {
//         
//
//         public Dictionary<string, Item> slots;
//         public EquipmentModule(Unit _mono) : base(_mono)
//         {
//             InitSlots();
//         }
//         void InitSlots()
//         {
//
//         }
//         public override void AddItem(Item item, object index)
//         {
//
//                 if (index is string i)
//                 {
//                     slots[i] = item;
//                     Draw();
//                 }
//             
//         }
//         public override Item GetItem(object index)
//         {
//             if (index is string i)
//                 return slots[i];
//             else return null;
//         }
//         public override void MoveItem(ItemBasedModule from, object index, Vector2Int pos)
//         {
//             Item item = from.GetItem(index);
//             string slot="";
//             
//             if(item is IEquipable equip)
//             {
//                 slot = equip.Slot;
//             }
//             Item removed = RemoveItem(slot);
//             AddItem(item, slot);
//             if (removed != null)
//                 from.AddItem(removed,null);
//         }
//         public override Item RemoveItem(object index)
//         {
//             if(index is string i)
//             {
//                 Item item= (Item)slots[i];
//                 slots[i] = null;
//                 Draw();
//                 return item;
//             }
//             throw new System.NotImplementedException();
//         }
//     }
// }