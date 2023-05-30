using System.Collections.Generic;
using UnityEngine;

namespace Units.Modules
{
    public abstract class BehaviourModule
    {
        protected Unit mono;
        protected Transform transform;
        protected Agent Mono
        { get => mono as Agent; }
        public BehaviourModule(Unit _mono)
        {
            mono = _mono;
            transform = mono.transform;
        }
    }
}