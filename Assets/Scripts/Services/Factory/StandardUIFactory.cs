using Core.Game.Controllers;
using Core.Game.UI;
using Core.MainMenu.UI;
using Infrastructure.StateMachine.Game;
using Services.Assets;
using Services.Scene;
using UnityEngine;

namespace Services.Factory
{
    public class StandardUIFactory : IUIFactory
    {
        private readonly IAssetProvider _assetProvider;
        private readonly IGameStateMachine _gameStateMachine;
        private readonly GameController _gameController;

        public StandardUIFactory(IAssetProvider assetProvider, IGameStateMachine gameStateMachine, 
            GameController gameController)
        {
            _assetProvider = assetProvider;
            _gameStateMachine = gameStateMachine;
            _gameController = gameController;
        }
        
        public MainMenuUIController MainMenuUIController { get; private set; }
        public AfterMatchUIController AfterMatchUIController { get; private set; }

        public void CreateMainMenu()
        {
            GameObject gameObject = _assetProvider.GetMainMenuPrefab();
            GameObject createdObject = Object.Instantiate(gameObject);
            MainMenuUI mainMenuUI = createdObject.GetComponent<MainMenuUI>();
            MainMenuUIController mainMenuUIController = new MainMenuUIController(mainMenuUI, _gameStateMachine);
            MainMenuUIController = mainMenuUIController;
        }

        public void CreateAfterMatchScreen()
        {
            GameObject gameObject = _assetProvider.GetAfterScreenPrefab();
            GameObject createdObject = Object.Instantiate(gameObject);
            AfterMatchUI afterMatchUI = createdObject.GetComponent<AfterMatchUI>();
            AfterMatchUIController afterMatchUIController = new AfterMatchUIController(afterMatchUI, _gameController,
                _gameStateMachine);
            AfterMatchUIController = afterMatchUIController;
        }
    }
}