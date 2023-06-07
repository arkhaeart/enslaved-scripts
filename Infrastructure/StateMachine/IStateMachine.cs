namespace Infrastructure.StateMachine
{
    public interface IStateMachine
    {
        void Process<T>(System.Type target,T data,string layerName ="");
        void TryChangeState(System.Type type,string layerName="");
    }
}