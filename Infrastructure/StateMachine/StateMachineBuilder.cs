using System;
using System.Collections.Generic;
using Common.Utilities;
using Infrastructure.StateMachine.Scriptable;
using Zenject;

namespace Infrastructure.StateMachine
{
    public class StateMachineBuilder
    {
        private readonly StateTypeToNameConfig stateTypeToNameConfig;
        [Inject]
        public StateMachineBuilder(StateTypeToNameConfig stateTypeToNameConfig)
        {
            this.stateTypeToNameConfig = stateTypeToNameConfig;
        }
        public IStateMachine Build(AgentStateMachineData agentStateMachineData)
        {
            var stateMachine = new IndexPassingStateMachine();
            Dictionary<string, StateLayer> layers = new Dictionary<string, StateLayer>();
            BuildLayers(agentStateMachineData, layers);
            stateMachine.SetLayers(layers);
            return stateMachine;
        }

        private void BuildLayers(AgentStateMachineData agentStateMachineData, Dictionary<string, StateLayer> layers)
        {
            int layersCount = agentStateMachineData.layerDatas.Length;
            foreach (var layerData in agentStateMachineData.layerDatas)
            {
                BuildLayer(layers, layerData,layersCount==1);
            }
        }

        private void BuildLayer(Dictionary<string, StateLayer> layers, LayerData layerData,bool singleLayer)
        {
            StateLayer layer = new StateLayer();
            string layerName = layerData.name;
            if (string.IsNullOrEmpty(layerName) || singleLayer)
                layerName = "default";
            FillLayerWithStates(layer, layerData);
            layers.Add(layerName, layer);
        }

        void FillLayerWithStates(StateLayer layer, LayerData layerData)
        {
            Dictionary<System.Type, StateInfo> states = new Dictionary<Type, StateInfo>();
            foreach (var stateData in layerData.stateDatas)
            {
                var state = GetState(stateData);
                var linkTypes = GetLinkTypes(stateData);
                var stateInfo = new StateInfo(state, linkTypes, stateData.overriding);
                states.Add(state.GetType(),stateInfo);
            }

            layer.states = states;
        }

        private HashSet<Type> GetLinkTypes(StateData stateData)
        {
            HashSet<System.Type> linkTypes = new HashSet<Type>();
            foreach (var linkData in stateData.links)
            {
                string linkTypeName = stateTypeToNameConfig.typeDict[linkData.name];
                linkTypes.Add(System.Type.GetType(linkTypeName));
            }

            return linkTypes;
        }

        private IState GetState(StateData stateData)
        {
            string stateType = stateTypeToNameConfig.typeDict[stateData.type];
            var state = TypesUtility.Create<IState>(stateType);
            return state;
        }
    }
}