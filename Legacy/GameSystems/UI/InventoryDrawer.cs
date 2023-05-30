// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using GameSystems;
// using Units.Modules;
// using Items;
// namespace UI
// {
//     public partial class InventoryDrawer : UIDrawer
//     {
//         public static event System.Action<InventoryGridHolder> InventoryHolderToggle;
//         /// <summary>
//         /// MAKE SPECIAL EFFORT TO FILL THESE WITH UP TO DATE INFO!!!
//         /// </summary>
//         public Dictionary<string,InventoryCard> cardsDict=new Dictionary<string,InventoryCard>();
//         public List<InventoryGridItem> gridItems = new List<InventoryGridItem>();
//         public Queue<InventoryGridItem> unusedGridItems = new Queue<InventoryGridItem>();
//         public CustomCour drawing;
//         WaitForSeconds fastRefresh;
//         protected override void Awake()
//         {
//             base.Awake();
//             foreach(var gridItem in gridItems)
//             {
//                 unusedGridItems.Enqueue(gridItem);
//             }
//             drawing = new CustomCour(this, new System.Func<IEnumerator>(Drawing));
//             fastRefresh = new WaitForSeconds(0.5f);
//         }
//         private void Start()
//         {
//             LootActionUsage.OnInventoryLooted += AttachModule;
//         }
//         IEnumerator Drawing()
//         {
//             foreach (var card in cardsDict.Values)
//             {
//                 if (card.module == null)
//                     card.holder.gameObject.SetActive(false);
//                 else if(!card.holder.gameObject.activeSelf)card.holder.gameObject.SetActive(true);
//
//             }
//             while (true)
//             {
//                 foreach(var card in cardsDict.Values)
//                 {
//                     if (card.module!=null)
//                         DrawCard(card);
//                     else
//                     {
//                         
//                     }
//                 }
//                 yield return fastRefresh;
//             }
//         }
//         void CheckCard(InventoryCard card, out List<int> pluses, out List<int> minuses)
//         {
//             pluses = new List<int>();
//             minuses = new List<int>();
//             if(card.holder!=null&&card.module!=null)
//             {
//
//                 
//                 // foreach (var itemToDraw in card.module.itemsToDraw)
//                 // {
//                 //     if(card.holder.currentlyDrawn.ContainsKey(itemToDraw.Key))
//                 //     {
//                 //         continue;
//                 //     }
//                 //     else
//                 //     {
//                 //         pluses.Add(itemToDraw.Key);
//                 //     }
//                 // }
//                 foreach (var itemDrawn in card.holder.currentlyDrawn)
//                 {
//                     // if (card.module.itemsToDraw.ContainsKey(itemDrawn.Key))
//                     // {
//                     //     continue;
//                     // }
//                     // else
//                     // {
//                     //     minuses.Add(itemDrawn.Key);
//                     // }
//                 }
//             }
//         }
//         public void DrawCard(InventoryCard card)
//         {
//             
//             CheckCard(card, out List<int> pluses, out List<int> minuses);
//
//             foreach(int plus in pluses)
//             {
//                 // var itemToDraw = card.module.itemsToDraw[plus];
//                 // InventoryGridItem item = unusedGridItems.Dequeue();
//                 // item.invIndex = plus;
//                 // item.item = itemToDraw.item;
//                 // item.image.sprite = item.item.uiSprite;
//                 // item.transform.SetParent(card.holder.transform);
//                 // item.rectTransform.sizeDelta = new Vector2(item.item.X * card.holder.cellExample.rect.width, item.item.Y * card.holder.cellExample.rect.height);
//                 //
//                 // card.holder.DrawItem(item,itemToDraw.cell.pos,plus);
//             }
//             foreach(var minus in minuses)
//             {
//                 InventoryGridItem item=card.holder.GiveItem(minus);
//                 unusedGridItems.Enqueue(item);
//
//             }
//    
//             
//         }
//
//     }
//
//     public partial class InventoryDrawer : UIDrawer
//     {
//         public void AttachModule(InventoryModule module)
//         {
//
//             InventoryCard card = GetCardByType(module);
//             if (card.module != module)
//             {
//                 Debug.Log($"Module {module} attached to holder!");
//                 card.module = module;
//                 //card.module.DrawCall += () => { DrawCard(card); };
//                 InventoryHolderToggle(card.holder);
//             }
//         }
//         InventoryCard GetCardByType(InventoryModule module)
//         {
//             if (module.type == InventoryModule.Type.AGENT)
//             {
//                 Debug.Log("Other inventory drawn");
//                 return cardsDict["other"];
//             }
//             else
//             {
//                 Debug.Log("Container inventory drawn");
//                 return cardsDict["container"];
//             }
//         }
//         public void DetachModule(InventoryModule module)
//         {
//             InventoryCard card = GetCardByType(module);
//             if (card.module != null)
//             {
//                 //module.DrawCall -= () => { DrawCard(card); };
//                 card.module = null;
//                 InventoryHolderToggle(card.holder);
//             }
//         }
//     }
// }