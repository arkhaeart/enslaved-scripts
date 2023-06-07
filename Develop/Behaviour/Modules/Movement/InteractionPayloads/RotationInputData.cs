using UnityEngine;

namespace Develop.Behaviour.Modules
{
    public struct RotationInputData:IMovementComponent
    {
        private Vector2 deltaInput;

        public RotationInputData(Vector2 deltaInput)
        {
            this.deltaInput = deltaInput;
        }
        public void Interact(MovementModule movementModule)
        {
            movementModule.LookInput(deltaInput);
        }
    }
}