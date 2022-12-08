using Infrastructure.Locator;
using UnityEngine;

namespace Core.Game.Controllers.Spawner
{
    public interface IEnemySpawner : IService
    {
        void CreateEnemies(Vector2[] positions);
        void DeInitialize();
    }
}