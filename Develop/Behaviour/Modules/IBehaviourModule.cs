using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Develop.Behaviour
{
    public abstract class BehaviourModuleBase<TPayload>where TPayload:IBehaviourInteractionData
    {
        public abstract void Interact(TPayload payload);
        protected IAgentDataStorage agentDataStorage;
    }
    
}