using System;
using Core.Game.EnemyEntity;
using Extentions;
using Services.Factory.EnemyEntity;
using UnityEngine;
using UnityEngine.Pool;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace Core.Game.Controllers.Spawner
{
    public class EnemySpawner : IEnemySpawner
    {
        private readonly IEnemyFactory _enemyFactory;
        private readonly GameController _gameController;
        private readonly IObjectPool<Enemy> _pool;

        private readonly int _typeCount;

        public EnemySpawner(IEnemyFactory enemyFactory, GameController gameController)
        {
            _typeCount = Enum.GetNames(typeof(EnemyType)).Length;
            _enemyFactory = enemyFactory;
            _gameController = gameController;

            _pool = new ObjectPool<Enemy>(CreateEnemy, OnTakeFromPool, OnReturnedToPool,
                OnDestroyPoolObject);
        }

        public void DeInitialize() => 
            _pool.Clear();

        public void CreateEnemies(Vector2[] positions)
        {
            _gameController.SetMaxEnemiesOnLevel(positions.Length);
            
            foreach (Vector2 position in positions)
            {
                GetEnemy(position)
                    .Force();
            }
        }

        private void OnDestroyPoolObject(Enemy obj)
        {
            obj.OnDied -= PoolEnemy;
            obj.OnAfterDeath -= _gameController.IncreaseDiedEnemies;
            Object.Destroy(obj.gameObject);
        }

        private void OnReturnedToPool(Enemy obj) => 
            obj.gameObject.SetActive(false);

        private void OnTakeFromPool(Enemy obj)
        {
            obj.ResetToDefault();
            obj.gameObject.SetActive(true);
        }

        private Enemy CreateEnemy()
        {
            EnemyType enemyType = (EnemyType)Random.Range(0, _typeCount);
            Enemy enemy = _enemyFactory.CreateEnemy(enemyType)
                .With(x => x.OnDied += PoolEnemy)
                .With(x => x.OnAfterDeath += _gameController.IncreaseDiedEnemies);
            return enemy;
        }

        private void PoolEnemy(Enemy obj) => 
            _pool.Release(obj);

        private Enemy GetEnemy(Vector2 position) =>
            _pool.Get().With(x => x.SetPosition(position));
    }
}