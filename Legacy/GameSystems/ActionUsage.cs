// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using Units;
// using Items;
// using Units.Modules;
//
// namespace GameSystems
// {
//     public abstract class ActionUsage
//     {
//
//         public abstract void Use(Agent user,Unit unit);
//
//     }
//     public class TakeActionUsage : ActionUsage
//     {
//
//         public override void Use(Agent user, Unit unit)
//         {
//             Item item = GetItem(unit);
//             user.IModule.AddItem(item,null);
//             unit.gameObject.SetActive(false);
//         }
//         Item GetItem(Unit unit)
//         {
//             SceneItem scene = (SceneItem)unit;
//             return scene.item;
//         }
//     }
//     public class LootActionUsage:ActionUsage
//     {
//         public static event System.Action<InventoryModule> OnInventoryLooted;
//         public override void Use(Agent user, Unit unit)
//         {
//             if(unit is IInventoryUser loot)
//             {
//                 OnInventoryLooted?.Invoke(loot.IModule);
//             }
//             
//         }
//     }
//     public class SpeakActionUsage : ActionUsage
//     {
//         public override void Use(Agent user, Unit unit)
//         {
//             Debug.Log($"{user.name} speaked with {unit.name}");
//         }
//     }
//     public class WorkActionUsage : ActionUsage
//     {
//
//         public override void Use(Agent user, Unit unit)
//         {
//             if (unit is IInventoryUser loot)
//             {
//
//                 //UI.DrawManager.Instance.AttachModule(loot.IModule);
//             }
//         }
//     }
//
// }