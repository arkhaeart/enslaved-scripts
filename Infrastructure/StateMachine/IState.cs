using System.Collections.Generic;

namespace Infrastructure.StateMachine
{
    public interface IState
    {
        void Enter(IIndexStateMachineUser user);
        void Exit(IIndexStateMachineUser user);
        void Process(IIndexStateMachineUser user);
    }
}