using System;
using UnityEngine;

namespace Develop.Behaviour.Modules
{
    public class MovementModule:BehaviourModuleBase<IMovementComponent>
    {
        public override void Interact(IMovementComponent payload)
        {
            payload.Interact(this);
            
        }

        public void MoveInput(Vector2 direction)
        {
            
        }

        public void LookInput(Vector2 deltaRotation)
        {
            
        }
    }
}