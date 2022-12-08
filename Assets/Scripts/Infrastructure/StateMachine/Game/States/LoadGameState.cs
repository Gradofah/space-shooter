using Services.Factory;
using Services.Scene;

namespace Infrastructure.StateMachine.Game.States
{
    public class LoadGameState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly ISceneLoader _sceneLoader;
        private readonly IGameFactory _gameFactory;
        private readonly IUIFactory _uiFactory;

        public LoadGameState(IGameStateMachine gameStateMachine, ISceneLoader sceneLoader, IGameFactory gameFactory, 
            IUIFactory uiFactory)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _gameFactory = gameFactory;
            _uiFactory = uiFactory;
        }
        
        public void Enter()
        {
            _sceneLoader.LoadSceneAsync("Game", CreateGameWorld);
        }

        public void Exit()
        {
            
        }

        private void CreateGameWorld()
        {
            _gameFactory.CreateBackground();
            _gameFactory.CreatePlayer();
            _uiFactory.CreateAfterMatchScreen();

            _gameStateMachine.Enter<GameState>();
        }
    }
}