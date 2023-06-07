namespace Infrastructure.StateMachine
{
    public interface IIndexStateMachineUser
    {
        void StateInput(int state);
    }
    public interface IDataStateMachineUser
    {
        void StateInput(object data);
    }
}