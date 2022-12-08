using System;
using Infrastructure.Locator;
using Infrastructure.StateMachine.Game;
using Infrastructure.StateMachine.Game.States;
using Services;
using UnityEngine;

namespace Infrastructure
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        private IGameStateMachine _gameStateMachine;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        private void Start()
        {
            _gameStateMachine = new GameStateMachine(ServiceLocator.Container, this);
            _gameStateMachine.Enter<BootstrapState>();
        }
    }
}