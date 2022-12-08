using Configuration;
using Core.Game.EnemyEntity;
using Core.Game.EnemyEntity.EnemyBehaviour.DirectionBehaviour;
using Extentions;
using Services.Assets;
using Services.Configuration;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Services.Factory.EnemyEntity
{
    public class EnemyFactory : IEnemyFactory
    {
        private readonly IConfigurationProvider _configurationProvider;
        private readonly IAssetProvider _assetProvider;

        public EnemyFactory(IConfigurationProvider configurationProvider, IAssetProvider assetProvider)
        {
            _configurationProvider = configurationProvider;
            _assetProvider = assetProvider;
        }
        
        public Enemy CreateEnemy(EnemyType enemyType)
        {
            EnemyEntityConfiguration configuration = _configurationProvider.GetEnemyEntityConfiguration();

            Enemy enemy;
            
            switch (enemyType)
            {
                case EnemyType.Strong:
                    enemy = CreateEnemyLocally();
                    enemy
                        .With(x => x.SetSpeed(configuration.StrongSpeed))
                        .With(x => x.SetHealth(configuration.StrongHealth))
                        .With(x => x.SetSprite(configuration.StrongEnemySprite))
                        .With(x => x.SetBodySize(configuration.StrongSize))
                        .With(x => x.SetDirectionBehaviour(new ReflectDirectionBehaviour()));
                    break;
                case EnemyType.Fast:
                    enemy = CreateEnemyLocally();
                    enemy
                        .With(x => x.SetSpeed(configuration.FastSpeed))
                        .With(x => x.SetHealth(configuration.FastHealth))
                        .With(x => x.SetSprite(configuration.FastEnemySprite))
                        .With(x => x.SetBodySize(configuration.FastSize))
                        .With(x => x.SetDirectionBehaviour(new OffsetReflectDirectionBehaviour()));
                    return enemy;
                default:
                    Debug.Log($"No such type of enemy...");
                    return null;
            }

            return enemy;
        }

        private Enemy CreateEnemyLocally() => 
            Object.Instantiate(_assetProvider.GetEnemyPrefab())
                .GetComponent<Enemy>();
    }
}