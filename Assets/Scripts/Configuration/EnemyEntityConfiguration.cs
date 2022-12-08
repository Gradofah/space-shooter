using UnityEngine;

namespace Configuration
{
    [CreateAssetMenu(fileName = "Enemy Entity Configuration", menuName = "Configuration/Game/Enemy Entity", order = 0)]
    public class EnemyEntityConfiguration : ScriptableObject
    {
        [Header("Strong")] 
        [SerializeField] private float _strongSpeed;
        [SerializeField] private float _strongHealth;
        [SerializeField] private Sprite _strongEnemySprite;
        [SerializeField] private Vector3 _strongSize;
        
        [Header("Fast")] 
        [SerializeField] private float _fastSpeed;
        [SerializeField] private float _fastHealth;
        [SerializeField] private Sprite _fastEnemySprite;
        [SerializeField] private Vector3 _fastSize;

        public float StrongSpeed => _strongSpeed;
        public float StrongHealth => _strongHealth;
        public Sprite StrongEnemySprite => _strongEnemySprite;
        public Vector3 StrongSize => _strongSize;

        public float FastSpeed => _fastSpeed;
        public float FastHealth => _fastHealth;
        public Sprite FastEnemySprite => _fastEnemySprite;
        public Vector3 FastSize => _fastSize;
    }
}