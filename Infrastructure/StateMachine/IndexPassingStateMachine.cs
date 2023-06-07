using System;
using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure.StateMachine
{
    public class IndexPassingStateMachine:IStateMachine
    {
        private string name;
        private Dictionary<string, StateLayer> layers;
        private IIndexStateMachineUser stateMachineUser;
        public virtual void Process<T>(System.Type target,T data, string layerName = "default")
        {
            if (layers.TryGetValue(layerName, out var layer))
            {
                layer.Process(target,stateMachineUser);
            }
            else
            {
                Debug.LogError($"Tried to access non existent layer {layerName} on state machine {name}");
            }
        }

        public virtual void TryChangeState(Type type, string layerName = "default")
        {
            if (layers.TryGetValue(layerName, out var layer))
            {
                layer.TryChangeState(type,stateMachineUser);
            }
            else
            {
                Debug.LogError($"Tried to access non existent layer {layerName} on state machine {name}");
            }
        }

        public void SetLayers(Dictionary<string, StateLayer> layers)
        {
            this.layers = layers;
        }
    }
}