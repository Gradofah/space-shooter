namespace Infrastructure.StateMachine.Game
{
    public interface IState
    {
        void Enter();
        void Exit();
    }
}