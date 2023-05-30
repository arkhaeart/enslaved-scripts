using System;
using System.Collections.Generic;
using Infrastructure.States;
using UnityEngine;

namespace _Car_Parking.Scripts.Infrastructure.States
{
    public class SimpleStateMachine : IGameStateMachine
    {
        public IExitableState ActiveState { get; set; }

        Dictionary<Type, IExitableState> states = new Dictionary<Type, IExitableState>();

        public SimpleStateMachine(params IExitableState[] states)
        {
            foreach (var state in states)
            {
                this.states.Add(state.GetType(), state);
            }
        }

        public void Enter<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadState<TPayload>
        {
            TState state = ChangeState<TState>();
            state.Enter(payload);
        }

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            ActiveState?.Exit();
            TState state = GetState<TState>();
            ActiveState = state;
            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState
        {
            return (TState)states[typeof(TState)];
        }
    }
}

