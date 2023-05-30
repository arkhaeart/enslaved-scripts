// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// namespace GameSystems
// {
//     public class ActionUsageFactory
//     {
//         TakeActionUsage take;
//         WorkActionUsage work;
//         LootActionUsage loot;
//         SpeakActionUsage speak;
//
//         public ActionUsageFactory()
//         {
//             CreateActionUsages();
//             InitActionUsages();
//         }
//         public Dictionary<UseAction,ActionUsage> GetDict()
//         {
//             Dictionary<UseAction, ActionUsage> dict = new Dictionary<UseAction, ActionUsage>();
//             dict.Add(UseAction.LOOT, loot);
//             dict.Add(UseAction.TAKE, take);
//             dict.Add(UseAction.WORK, work);
//             dict.Add(UseAction.SPEAK, speak);
//             return dict;
//
//         }
//         void CreateActionUsages()
//         {
//             take = new TakeActionUsage();
//             work = new WorkActionUsage();
//             loot = new LootActionUsage();
//             speak = new SpeakActionUsage();
//
//         }
//         void InitActionUsages()
//         {
//
//         }
//     }
// }
