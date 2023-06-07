namespace Develop.Behaviour.Modules
{
    public interface IMovementComponent:IBehaviourInteractionData
    {
        void Interact(MovementModule movementModule);
    }
}