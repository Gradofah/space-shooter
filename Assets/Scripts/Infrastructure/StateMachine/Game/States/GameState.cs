using Configuration;
using Core.Game.Controllers;
using Core.Game.Controllers.Spawner;
using Services.Configuration;
using Services.Factory;

namespace Infrastructure.StateMachine.Game.States
{
    public class GameState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IEnemySpawner _enemySpawner;
        private readonly IConfigurationProvider _configurationProvider;
        private readonly GameController _gameController;
        private readonly IUIFactory _uiFactory;
        private readonly IBulletSpawner _bulletSpawner;

        public GameState(IGameStateMachine gameStateMachine, IEnemySpawner enemySpawner,
            IConfigurationProvider configurationProvider, GameController gameController, IUIFactory uiFactory, 
            IBulletSpawner bulletSpawner)
        {
            _gameStateMachine = gameStateMachine;
            _enemySpawner = enemySpawner;
            _configurationProvider = configurationProvider;
            _gameController = gameController;
            _uiFactory = uiFactory;
            _bulletSpawner = bulletSpawner;
        }
        
        public void Enter()
        {
            _uiFactory.AfterMatchUIController.Initialize();
            SpawnConfiguration configuration = _configurationProvider.GetEnemySpawnConfiguration();
            _enemySpawner.CreateEnemies(configuration.SpawnPositions);
            _gameController.StartLevel();
        }

        public void Exit()
        {
            _uiFactory.AfterMatchUIController.DeInitialize();
            _enemySpawner.DeInitialize();
            _bulletSpawner.DeInitialize();
        }
    }
}