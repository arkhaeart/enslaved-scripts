using UnityEngine;

namespace Develop.Behaviour.Modules
{
    public struct MovementInputData:IMovementComponent
    {
        private Vector2 direction;

        public MovementInputData(Vector2 direction)
        {
            this.direction = direction;
        }
        public void Interact(MovementModule movementModule)
        {
            movementModule.MoveInput(direction);
        }
    }
}