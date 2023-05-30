using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Units
{
    
    public class ManualAgent : Agent
    {
        Coroutine movement;
        CustomCour inputBlocked;
        InputState<bool> blockResponse;
        //protected  void Start()
        //{

        //    GameSystems.InputManager inputManager=GameSystems.InputManager.Instance;
        //    inputManager.MovResponse += MovementResponse;
        //    inputManager.MouseResponse += MouseMovementResponse;
        //    inputManager.AttackResponse += AttackResponse;
        //    inputManager.InputBlocked += InputBlocked;
        //    inputBlocked = new CustomCour(this, new System.Func<IEnumerator>(BlockingInput));
        //    blockResponse = new InputState<bool>(inputManager.BlockResponse,new System.Action<bool>(BlockResponse));
        //}

        IEnumerator BlockingInput()
        {

            while (true)
                yield return null;
        }
        void InputBlocked()
        {
            if (!inputBlocked.IsActive)
                inputBlocked.Run();
            else inputBlocked.Stop();
        }
        void MovementResponse(Vector2 dir)
        {
            if (inputBlocked.IsActive)
                return;
            mModule.CheckCurrentPath();
            mModule.Move(dir);
        }
        void MouseMovementResponse(Vector2 target)
        {
            if (inputBlocked.IsActive)
                return;
            mModule.CheckCurrentPath();
            mModule.RequestPath(target);
        }
        void AttackResponse(Vector2 target)
        {
            if (inputBlocked.IsActive)
                return;
            Vector2 direction = target-(Vector2)transform.position  ;
            Debug.Log($"{name} performed attack in direction {direction}");
            cModule.RenderHit(direction);
        }
        void BlockResponse(bool pressed)
        {
            Debug.Log("block pressed");
            if (inputBlocked.IsActive)
                return;
            if (pressed)
                cModule.RenderBlock();
            else
                cModule.StopBlock();
        }

    }
}