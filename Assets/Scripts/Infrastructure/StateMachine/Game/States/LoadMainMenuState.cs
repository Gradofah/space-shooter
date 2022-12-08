using Services.Factory;
using Services.Scene;

namespace Infrastructure.StateMachine.Game.States
{
    public class LoadMainMenuState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IUIFactory _uiFactory;
        private readonly ISceneLoader _sceneLoader;

        public LoadMainMenuState(IGameStateMachine gameStateMachine, IUIFactory uiFactory, ISceneLoader sceneLoader)
        {
            _gameStateMachine = gameStateMachine;
            _uiFactory = uiFactory;
            _sceneLoader = sceneLoader;
        }
        
        public void Enter()
        {
            _sceneLoader.LoadSceneAsync("MainMenu", CreateMainMenu);
        }

        public void Exit()
        {
            
        }

        private void CreateMainMenu()
        {
            _uiFactory.CreateMainMenu();
            _gameStateMachine.Enter<MainMenuState>();
        }
    }
}