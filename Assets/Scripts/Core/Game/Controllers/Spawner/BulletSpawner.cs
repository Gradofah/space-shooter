using Core.Game.BulletEntity;
using Extentions;
using Services.Factory.BulletEntity;
using UnityEngine;
using UnityEngine.Pool;

namespace Core.Game.Controllers.Spawner
{
    public class BulletSpawner : IBulletSpawner
    {
        private readonly IBulletFactory _bulletFactory;
        private readonly IObjectPool<Bullet> _pool;

        public BulletSpawner(IBulletFactory bulletFactory)
        {
            _bulletFactory = bulletFactory;

            _pool = new ObjectPool<Bullet>(CreateBullet, OnTakeFromPool, OnReturnedToPool,
                OnDestroyPoolObject);
        }

        public void DeInitialize() => 
            _pool.Clear();

        public void SpawnBullet(Vector3 position, Vector3 direction)
        {
            _pool.Get()
                .With(x => x.SetPosition(position))
                .With(x => x.Force(direction));
        }

        private Bullet CreateBullet()
        {
            Bullet bullet = _bulletFactory.CreateBullet()
                .With(x => x.OnCollideWithEnemy += PoolBullet)
                .With(x => x.OnCollideWithSomething += PoolBullet);
            return bullet;
        }

        private void OnDestroyPoolObject(Bullet obj)
        {
            obj.OnCollideWithEnemy -= PoolBullet;
            obj.OnCollideWithSomething -= PoolBullet;
            Object.Destroy(obj.gameObject);
        }

        private void OnReturnedToPool(Bullet obj) => 
            obj.gameObject.SetActive(false);

        private void OnTakeFromPool(Bullet obj) => 
            obj.gameObject.SetActive(true);

        private void PoolBullet(Bullet obj) => 
            _pool.Release(obj);
    }
}