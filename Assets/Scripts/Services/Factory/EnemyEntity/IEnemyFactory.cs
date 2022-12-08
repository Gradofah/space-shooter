using Core.Game.EnemyEntity;
using Infrastructure.Locator;

namespace Services.Factory.EnemyEntity
{
    public interface IEnemyFactory : IService
    {
        Enemy CreateEnemy(EnemyType enemyType);
    }
}