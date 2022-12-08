using Core.Game.Controllers;
using Core.Game.Controllers.Spawner;
using Infrastructure.Locator;
using Services;
using Services.Assets;
using Services.Configuration;
using Services.Factory;
using Services.Factory.BulletEntity;
using Services.Factory.EnemyEntity;
using Services.Input;
using Services.Scene;
using Services.Time;

namespace Infrastructure.StateMachine.Game.States
{
    public class BootstrapState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly ServiceLocator _serviceLocator;
        private readonly ICoroutineRunner _coroutineRunner;

        public BootstrapState(IGameStateMachine gameStateMachine, ServiceLocator serviceLocator,
            ICoroutineRunner coroutineRunner)
        {
            _gameStateMachine = gameStateMachine;
            _serviceLocator = serviceLocator;
            _coroutineRunner = coroutineRunner;

            RegisterServices();
        }
        
        public void Enter()
        {
            _gameStateMachine.Enter<LoadMainMenuState>();
        }

        public void Exit()
        {
            
        }

        private void RegisterServices()
        {
            _serviceLocator
                .RegisterSingle<IGameStateMachine>(_gameStateMachine);
            _serviceLocator
                .RegisterSingle<ICoroutineRunner>(_coroutineRunner);
            _serviceLocator
                .RegisterSingle<IInputService>(new PcInputService());
            _serviceLocator
                .RegisterSingle<IConfigurationProvider>(
                    new ResourcesConfigurationProvider());
            _serviceLocator
                .RegisterSingle<ITimer>(new StandardTimer());
            _serviceLocator
                .RegisterSingle<GameController>(
                    new GameController(_serviceLocator.Single<ITimer>(),
                        _serviceLocator.Single<ICoroutineRunner>(),
                    _serviceLocator.Single<IConfigurationProvider>()));
            _serviceLocator
                .RegisterSingle<IAssetProvider>(new ResourcesAssetProvider());
            _serviceLocator
                .RegisterSingle<ISceneLoader>(
                    new StandardSceneLoader());
            _serviceLocator
                .RegisterSingle<IBulletFactory>(
                    new BulletFactory(_serviceLocator.Single<IConfigurationProvider>(),
                        _serviceLocator.Single<IAssetProvider>()));
            _serviceLocator
                .RegisterSingle<IBulletSpawner>(
                    new BulletSpawner(_serviceLocator.Single<IBulletFactory>()));
            _serviceLocator
                .RegisterSingle<IGameFactory>(
                    new StandardGameFactory(
                        _serviceLocator.Single<IAssetProvider>(),
                        _serviceLocator.Single<IBulletSpawner>(),
                        _serviceLocator.Single<IInputService>()));
            _serviceLocator
                .RegisterSingle<IUIFactory>(
                    new StandardUIFactory(
                        _serviceLocator.Single<IAssetProvider>(), 
                        _serviceLocator.Single<IGameStateMachine>(),
                        _serviceLocator.Single<GameController>()));
            _serviceLocator
                .RegisterSingle<IEnemyFactory>(
                    new EnemyFactory(_serviceLocator.Single<IConfigurationProvider>(),
                        _serviceLocator.Single<IAssetProvider>()));
            _serviceLocator
                .RegisterSingle<IEnemySpawner>(
                    new EnemySpawner(_serviceLocator.Single<IEnemyFactory>(), 
                        _serviceLocator.Single<GameController>()));
        }
    }
}