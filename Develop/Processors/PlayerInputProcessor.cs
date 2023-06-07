using Develop.Behaviour;
using Develop.Behaviour.Modules;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityGenerated;
using Zenject;

namespace Develop.Processors
{
    public class PlayerInputProcessor
    {
        private readonly PlayerActions playerActions;
        private BehaviourModuleBase<IMovementComponent>? listener;
        [Inject]
        public PlayerInputProcessor(PlayerActions playerActions)
        {
            this.playerActions = playerActions;
        }

        public void Subscribe(BehaviourModuleBase<IMovementComponent> listener)
        {
            this.listener = listener;
        }

        public void Unsubscribe()
        {
            
            listener = null;
        }

        public void Initialize()
        {
            playerActions.PlayerMelee.AddCallbacks(new PlayerMeleeActionsInputListener(this));
            playerActions.PlayerMelee.Enable();
        }

        public void MovementInput(Vector2 direction)
        {
            listener?.Interact(new MovementInputData(direction));
        }

        public void LookInput(Vector2 deltaInput)
        {
            listener?.Interact(new RotationInputData(deltaInput));
        }
    }

    public class PlayerMeleeActionsInputListener : PlayerActions.IPlayerMeleeActions
    {
        private readonly PlayerInputProcessor playerInputProcessor;

        public PlayerMeleeActionsInputListener(PlayerInputProcessor processor)
        {
            playerInputProcessor = processor;
        }
        public void OnLook(InputAction.CallbackContext context)
        {
            playerInputProcessor.LookInput(context.ReadValue<Vector2>());

        }

        public void OnMovement(InputAction.CallbackContext context)
        {
            playerInputProcessor.MovementInput(context.ReadValue<Vector2>());
        }
        public void OnAttack(InputAction.CallbackContext context)
        {
            throw new System.NotImplementedException();
        }

        public void OnChargedAttack(InputAction.CallbackContext context)
        {
            throw new System.NotImplementedException();
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            throw new System.NotImplementedException();
        }

        public void OnSprint(InputAction.CallbackContext context)
        {
            throw new System.NotImplementedException();
        }

        public void OnCrouch(InputAction.CallbackContext context)
        {
            throw new System.NotImplementedException();
        }

        public void OnInteract(InputAction.CallbackContext context)
        {
            throw new System.NotImplementedException();
        }

        public void OnBlock(InputAction.CallbackContext context)
        {
            throw new System.NotImplementedException();
        }

        
    }
}