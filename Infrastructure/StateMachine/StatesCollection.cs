using System;
using System.Collections.Generic;

namespace Infrastructure.StateMachine
{
    public class StatesCollection
    {
        public Dictionary<System.Type, IState> states;

        public StatesCollection(Dictionary<Type, IState> states)
        {
            this.states = states;
        }
    }
}