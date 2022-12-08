using Configuration;
using UnityEngine;

namespace Services.Configuration
{
    public class ResourcesConfigurationProvider : IConfigurationProvider
    {
        private const string EnemyEntityConfigurationPath = "Configurations/Enemy Entity Configuration";
        private const string SpawnConfigurationPath = "Configurations/Enemy Spawn Configuration";
        private const string GameConfigurationPath = "Configurations/Game Configuration";
        private const string BulletEntityConfigurationPath = "Configurations/Bullet Entity Configuration";
        
        public EnemyEntityConfiguration GetEnemyEntityConfiguration() => 
            Resources.Load<EnemyEntityConfiguration>(EnemyEntityConfigurationPath);

        public SpawnConfiguration GetEnemySpawnConfiguration() => 
            Resources.Load<SpawnConfiguration>(SpawnConfigurationPath);

        public GameConfiguration GetGameConfiguration() => 
            Resources.Load<GameConfiguration>(GameConfigurationPath);

        public BulletConfiguration GetBulletEntityConfiguration() => 
            Resources.Load<BulletConfiguration>(BulletEntityConfigurationPath);
    }
}