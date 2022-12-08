using System;
using System.Collections.Generic;
using Core.Game.Controllers;
using Core.Game.Controllers.Spawner;
using Infrastructure.Locator;
using Infrastructure.StateMachine.Game.States;
using Services;
using Services.Configuration;
using Services.Factory;
using Services.Scene;

namespace Infrastructure.StateMachine.Game
{
    public class GameStateMachine : IGameStateMachine
    {
        private readonly Dictionary<Type, IState> _states;
        private IState _activeState;
        
        public GameStateMachine(ServiceLocator serviceLocator, ICoroutineRunner coroutineRunner)
        {
            _states = new Dictionary<Type, IState>()
            {
                [typeof(BootstrapState)] = 
                    new BootstrapState(this, serviceLocator, coroutineRunner),
                [typeof(LoadMainMenuState)] = 
                    new LoadMainMenuState(this, serviceLocator.Single<IUIFactory>(),
                        serviceLocator.Single<ISceneLoader>()),
                [typeof(MainMenuState)] = 
                    new MainMenuState(this, serviceLocator.Single<IUIFactory>()),
                [typeof(LoadGameState)] = 
                    new LoadGameState(this, serviceLocator.Single<ISceneLoader>(),
                        serviceLocator.Single<IGameFactory>(),
                        serviceLocator.Single<IUIFactory>()),
                [typeof(GameState)] = 
                    new GameState(this, serviceLocator.Single<IEnemySpawner>(),
                        serviceLocator.Single<IConfigurationProvider>(), 
                        serviceLocator.Single<GameController>(),
                        serviceLocator.Single<IUIFactory>(),
                        serviceLocator.Single<IBulletSpawner>())
            };
        }

        public void Enter<TState>() where TState : IState
        {
            _activeState?.Exit();
            _activeState = _states[typeof(TState)];
            _activeState?.Enter();
        }
    }
}