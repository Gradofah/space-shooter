using UnityEngine;

namespace Configuration
{
    [CreateAssetMenu(fileName = "Enemy Spawn Configuration", menuName = "Configuration/Game/Enemy Spawn", order = 1)]
    public class SpawnConfiguration : ScriptableObject
    {
        [SerializeField] private Vector2[] _spawnPositions;

        public Vector2[] SpawnPositions => _spawnPositions;
    }
}