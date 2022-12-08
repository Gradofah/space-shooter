using Infrastructure.Locator;
using UnityEngine;

namespace Core.Game.Controllers.Spawner
{
    public interface IBulletSpawner : IService
    {
        void SpawnBullet(Vector3 position, Vector3 direction);
        void DeInitialize();
    }
}