using System;
using System.Collections.Generic;

namespace Infrastructure.StateMachine
{
    public class StateLayer
    {
        public Dictionary<System.Type, StateInfo> states;
        private StateInfo currentState;
        
        public void TryChangeState(System.Type target,IIndexStateMachineUser stateMachineUser)
        {
            
            if (states.TryGetValue(target, out var newStateData))
            {
                if (IsStateChangeEligible(target, newStateData))
                {
                    return;
                }
                currentState.State.Exit(stateMachineUser);
                currentState = newStateData;
                currentState.State.Enter(stateMachineUser);

            }
        }

        private bool IsStateChangeEligible(Type target, StateInfo newStateInfo)
        {
            return !newStateInfo.Overriding&&!currentState.Links.Contains(target);
        }

        public void Process(System.Type target,IIndexStateMachineUser user)
        {
            if (states.TryGetValue(target, out var stateData))
            {
                stateData.State.Process(user);
            }
        }
    }

    public record StateInfo(IState State, HashSet<System.Type> Links,bool Overriding);


}