using System.Collections;
using System.Collections.Generic;
using Develop.Behaviour;
using Units.Modules;
using UnityEngine;

namespace Develop
{
    public class Agent :IAgent
    {
        private Dictionary<System.Type, BehaviourModuleBase<IBehaviourInteractionData>> modulesDict;

        public void SetModule<T>(T module) where T : BehaviourModuleBase<IBehaviourInteractionData>
        {
            modulesDict.TryAdd(typeof(T), module);
        }
        private bool GetModule(System.Type type,out BehaviourModuleBase<IBehaviourInteractionData> module)
        {
            if (modulesDict.TryGetValue(type, out var bModule))
            {
                module = bModule;
                return true;
            }
            else
            {
                module = default;
                return false;
            }
        }

        public void InteractWithModule<T>(IBehaviourInteractionData behaviourInteractionData)
        {
            if (GetModule(typeof(T),out var module))
            {
                module.Interact(behaviourInteractionData);
            }
        }
    }
    public interface IAgent
    {
        public void InteractWithModule<T>(IBehaviourInteractionData behaviourInteractionData);
        void SetModule<T>(T module) where T : BehaviourModuleBase<IBehaviourInteractionData>;
    }

    public interface IAgentDataStorage
    { 
        int Id { get; }
        string Name { get; }
        
    }
}