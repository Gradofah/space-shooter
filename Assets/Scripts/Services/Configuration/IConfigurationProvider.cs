using Configuration;
using Infrastructure.Locator;

namespace Services.Configuration
{
    public interface IConfigurationProvider : IService
    {
        EnemyEntityConfiguration GetEnemyEntityConfiguration();
        SpawnConfiguration GetEnemySpawnConfiguration();
        GameConfiguration GetGameConfiguration();
        BulletConfiguration GetBulletEntityConfiguration();
    }
}