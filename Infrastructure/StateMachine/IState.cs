namespace Infrastructure.States
{
    public interface IState : IExitableState
    {
        void Enter();
    }
    
    public interface IPayloadState<TPayload> : IExitableState
    {
        void Enter(TPayload payLoad);
    }

    public interface IExitableState
    {
        void Exit();
    }
}