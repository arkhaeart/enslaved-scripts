// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using GameSystems;
// using Units.Modules;
// namespace UI
// {
//     public class DrawManager : MonoBehaviour
//     {
//         InventoryDrawer InvDrawer
//         {
//             get => (InventoryDrawer)drawers[typeof(InventoryDrawer)];
//         }
//         UseActionsDrawer UseDrawer
//         {
//             get => (UseActionsDrawer)drawers[typeof(UseActionsDrawer)];
//
//         }
//         public static Dictionary<System.Type, UIDrawer> drawers = new Dictionary<System.Type, UIDrawer>();
//         public static List<InventoryGridHolder> holderRegistry = new List<InventoryGridHolder>();
//
//         void Start()
//         {
//             InitInventoryDrawer();
//
//         }
//         void InitUseActionsDrawer()
//         {
//            
//         }
//         void InitInventoryDrawer()
//         {
//             foreach(var holder in holderRegistry)
//             {
//                 InventoryCard card = new InventoryCard(holder);
//                 InvDrawer.cardsDict.Add(holder.holderType, card);
//
//                 
//             }
//             foreach(var card in InvDrawer.cardsDict.Values)
//             {
//                 // if(card.module!=null)
//                 //     card.module.DrawCall += ()=> { InvDrawer.DrawCard(card); };
//                 card.holder.ItemMoved += (holder,index, pos) => { 
//                     if(card.module!=null)
//                         card.module.MoveItem(InvDrawer.cardsDict[holder.holderType].module, index, pos); };
//                 card.holder.gameObject.SetActive(false);
//             }
//             InvDrawer.drawing.Run();
//         }
//
//     }
// }