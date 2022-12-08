using Infrastructure.StateMachine.Game;
using Infrastructure.StateMachine.Game.States;

namespace Core.MainMenu.UI
{
    public class MainMenuUIController
    {
        private readonly MainMenuUI _mainMenuUI;
        private readonly IGameStateMachine _gameStateMachine;

        public MainMenuUIController(MainMenuUI mainMenuUI, IGameStateMachine gameStateMachine)
        {
            _mainMenuUI = mainMenuUI;
            _gameStateMachine = gameStateMachine;
        }

        public void Initialize() => 
            _mainMenuUI.PlayButton.onClick.AddListener(StartGame);

        public void DeInitialize() => 
            _mainMenuUI.PlayButton.onClick.RemoveAllListeners();

        private void StartGame() => 
            _gameStateMachine.Enter<LoadGameState>();
    }
}