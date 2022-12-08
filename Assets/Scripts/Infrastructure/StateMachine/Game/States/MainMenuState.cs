using Services.Factory;

namespace Infrastructure.StateMachine.Game.States
{
    public class MainMenuState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IUIFactory _uiFactory;

        public MainMenuState(IGameStateMachine gameStateMachine, IUIFactory uiFactory)
        {
            _gameStateMachine = gameStateMachine;
            _uiFactory = uiFactory;
        }
        
        public void Enter()
        {
            _uiFactory.MainMenuUIController.Initialize();
        }

        public void Exit()
        {
            _uiFactory.MainMenuUIController.DeInitialize();
        }
    }
}