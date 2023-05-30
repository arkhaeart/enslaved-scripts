// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using Units;
// using Items;
// using UI;
// namespace GameSystems
// {
//     public class UseActionManager 
//     {
//         public event System.Action<Dictionary<Unit, UseAction>> DrawCall;
//         
//         public Dictionary<Unit, UseAction> activeCards = new Dictionary<Unit, UseAction>();
//         public Dictionary<UseAction, ActionUsage> actionDict = new Dictionary<UseAction, ActionUsage>();
//         public LevelManager levelManager;
//         public void ActionRequest(Unit first, Unit second, UseAction useAction)
//         {
//
//         }
//         public void AddToPossibleActions(Unit unit,UseAction action)
//         {
//             activeCards.Add(unit, action);
//             Debug.Log($"Possible actions count: {activeCards.Count}");
//         }
//         public void RemoveFromPossibleActions(Unit unit)
//         {
//             activeCards.Remove(unit);
//             Debug.Log($"Possible actions count: {activeCards.Count}");
//
//         }
//         public void OnChoiceStart()
//         {
//             if(activeCards.Count>0)
//             {
//                 DrawCall(activeCards);
//             }
//         }
//         void CallUseAction(Unit unit)
//         {
//             ActionUsage usage = actionDict[activeCards[unit]];
//             activeCards.Remove(unit);
//             DrawCall(activeCards);
//             usage.Use(levelManager.player,unit);
//         }
//         public UseActionManager(InputManager inputManager, LevelManager levelManager)
//         {
//             inputManager.UseStartResponse += OnChoiceStart;
//             //SceneItem.TriggerEnter += AddToPossibleActions;
//             //SceneItem.TriggerExit += RemoveFromPossibleActions;
//             UseActionItem.Called += CallUseAction;
//             ActionUsageFactory factory = new ActionUsageFactory();
//             actionDict = factory.GetDict();
//             this.levelManager = levelManager;
//         }
//         //protected override void OnDisable()
//         //{
//         //    InputManager.Instance.UseStartResponse -= OnChoiceStart;
//         //    SceneItem.TriggerEnter -= AddToPossibleActions;
//         //    SceneItem.TriggerExit -= RemoveFromPossibleActions;
//         //    UseActionItem.Called -= CallUseAction;
//         //}
//     }
//     public enum UseAction
//     {
//         TAKE,
//         WORK,
//         SPEAK,
//         TRIG,
//         LOOT
//     }
//
// }