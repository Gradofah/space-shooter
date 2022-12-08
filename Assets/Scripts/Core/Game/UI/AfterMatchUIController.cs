using Core.Game.Controllers;
using Infrastructure.StateMachine.Game;
using Infrastructure.StateMachine.Game.States;

namespace Core.Game.UI
{
    public class AfterMatchUIController
    {
        private readonly AfterMatchUI _afterMatchUI;
        private readonly GameController _gameController;
        private readonly IGameStateMachine _gameStateMachine;

        public AfterMatchUIController(AfterMatchUI afterMatchUI, GameController gameController,
            IGameStateMachine gameStateMachine)
        {
            _afterMatchUI = afterMatchUI;
            _gameController = gameController;
            _gameStateMachine = gameStateMachine;
        }

        public void Initialize()
        {
            _afterMatchUI.RestartButton.onClick.AddListener(RestartGame);
            _gameController.OnLevelComplete += OpenWinScreen;
            _gameController.OnLevelLose += OpenLoseScreen;
        }

        public void DeInitialize()
        {
            _afterMatchUI.RestartButton.onClick.RemoveAllListeners();
            _gameController.OnLevelComplete -= OpenWinScreen;
            _gameController.OnLevelLose -= OpenLoseScreen;
        }

        private void OpenLoseScreen()
        {
            _afterMatchUI.gameObject.SetActive(true);
            _afterMatchUI.WinText.SetActive(false);
            _afterMatchUI.LoseText.SetActive(true);
        }

        private void OpenWinScreen()
        {
            _afterMatchUI.gameObject.SetActive(true);
            _afterMatchUI.LoseText.SetActive(false);
            _afterMatchUI.WinText.SetActive(true);
        }

        private void RestartGame()
        {
            _gameController.ResetLevel();
            _gameStateMachine.Enter<LoadMainMenuState>();
        }
    }
}