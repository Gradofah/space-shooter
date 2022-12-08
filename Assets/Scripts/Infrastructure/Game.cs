using Infrastructure.StateMachine.Game;

namespace Infrastructure
{
    public class Game
    {
        public readonly IGameStateMachine GameStateMachine;

        public Game(IGameStateMachine gameStateMachine)
        {
            GameStateMachine = gameStateMachine;
        }
    }
}