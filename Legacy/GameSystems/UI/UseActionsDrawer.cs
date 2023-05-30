// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using GameSystems;
// using Units;
// using Zenject;
//
// namespace UI
// {
//     public class UseActionsDrawer : UIDrawer
//     {
//         public event System.Action StoreAll;
//         public UseActionsMenu menu;
//         public List<UseActionItem> items = new List<UseActionItem>();
//         Dictionary<UseAction, string> useDict = new Dictionary<UseAction, string>
//         {
//             [UseAction.SPEAK] = "Speak to ",
//             [UseAction.TAKE] = "Take ",
//             [UseAction.WORK] = "Work with ",
//             [UseAction.TRIG] = "Use ",
//             [UseAction.LOOT]= "Loot through_ inventory"
//
//         };
//         protected override void Awake()
//         {
//             base.Awake();
//             StoreAll += menu.Store;
//             foreach(var item in items)
//             {
//                 StoreAll += item.Store;
//             }
//             StoreAll();
//         }
//         [Inject]
//         public void Initialize(UseActionManager useActionManager,InputManager inputManager)
//         {
//             useActionManager.DrawCall += DrawMenu;
//             inputManager.UseEndResponse += HideMenu;
//         }
//
//         public void DrawMenu(Dictionary<Unit,UseAction> cards)
//         {
//             HideMenu();
//             menu.SetSize(cards.Count);
//             int i = 0;
//             foreach(var pair in cards)
//             {
//                 string[] useMess = useDict[pair.Value].Split('_');
//                 string message;
//                 if (useMess.Length==1)
//                     message=string.Concat(useMess[0],char.ToLower(pair.Key.name[0]),pair.Key.name.Substring(1));
//                 else
//                     message= string.Concat(useMess[0], char.ToLower(pair.Key.name[0]), pair.Key.name.Substring(1),useMess[1]);
//                 items[i].Show(message,pair.Key);
//                 i++;
//             }
//
//         }
//         public void HideMenu()
//         {
//             StoreAll?.Invoke();
//         }
//     }
// }