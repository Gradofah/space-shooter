using Infrastructure.Locator;

namespace Infrastructure.StateMachine.Game
{
    public interface IGameStateMachine : IService
    {
        void Enter<TState>() where TState : IState;
    }
}