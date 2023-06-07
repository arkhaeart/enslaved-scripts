using System;
using System.Collections.Generic;
using Common.Utilities;
using Infrastructure.StateMachine.Scriptable;
using Zenject;

namespace Infrastructure.StateMachine
{
    public class StateCollectionFactory
    {
        private readonly StateTypeToNameConfig config;

        [Inject]
        public StateCollectionFactory(StateTypeToNameConfig config)
        {
            this.config = config;
        }

        public StatesCollection Create()
        {
            Dictionary<System.Type, IState> states = new Dictionary<Type, IState>();
            foreach (var entry in config.entries)
            {
                var state = TypesUtility.Create<IState>(entry.type);
                states.Add(state.GetType(),state);
            }
            StatesCollection collection = new StatesCollection(states);
            return collection;
        }
        
    }
}