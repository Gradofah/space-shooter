using System;
using System.Collections;
using Configuration;
using Infrastructure.Locator;
using Services;
using Services.Configuration;
using Services.Time;

namespace Core.Game.Controllers
{
    public class GameController : IService
    {
        private readonly ITimer _timer;
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly IConfigurationProvider _configurationProvider;

        private int _maxEnemiesOnLevel;
        private int _currentDiedEnemies;
        private bool _gameActive;
        private float _playTime;

        public event Action OnLevelComplete;
        public event Action OnLevelLose;

        public GameController(ITimer timer, ICoroutineRunner coroutineRunner,
            IConfigurationProvider configurationProvider)
        {
            _timer = timer;
            _coroutineRunner = coroutineRunner;
            _configurationProvider = configurationProvider;
        }

        public void StartLevel()
        {
            GameConfiguration configuration = _configurationProvider.GetGameConfiguration();
            _playTime = configuration.PlayTime;
            _gameActive = true;
            _coroutineRunner.StartCoroutine(TimerRoutine());
        }

        public void SetMaxEnemiesOnLevel(int value) => 
            _maxEnemiesOnLevel = value;

        public void IncreaseDiedEnemies()
        {
            _currentDiedEnemies++;

            if (_currentDiedEnemies >= _maxEnemiesOnLevel)
            {
                OnLevelComplete?.Invoke();
                _timer.Reset();
                _gameActive = false;
            }
        }

        public void ResetLevel()
        {
            _maxEnemiesOnLevel = 0;
            _currentDiedEnemies = 0;
        }

        private IEnumerator TimerRoutine()
        {
            while (_gameActive)
            {
                yield return null;
                _timer.Tick();

                if (_timer.CurrentTime >= _playTime)
                {
                    OnLevelLose?.Invoke();
                    _gameActive = false;
                    _timer.Reset();
                }
            }
        }
    }
}