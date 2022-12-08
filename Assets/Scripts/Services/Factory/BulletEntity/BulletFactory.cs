using Configuration;
using Core.Game.BulletEntity;
using Extentions;
using Services.Assets;
using Services.Configuration;
using UnityEngine;

namespace Services.Factory.BulletEntity
{
    public class BulletFactory : IBulletFactory
    {
        private readonly IConfigurationProvider _configurationProvider;
        private readonly IAssetProvider _assetProvider;

        public BulletFactory(IConfigurationProvider configurationProvider, IAssetProvider assetProvider)
        {
            _configurationProvider = configurationProvider;
            _assetProvider = assetProvider;
        }
        
        public Bullet CreateBullet()
        {
            BulletConfiguration configuration = _configurationProvider.GetBulletEntityConfiguration();
            Bullet bullet = Object.Instantiate(_assetProvider.GetBulletPrefab())
                .GetComponent<Bullet>()
                .With(x => x.SetDamage(configuration.Damage))
                .With(x => x.SetSpeed(configuration.Speed));
            return bullet;
        }
    }
}