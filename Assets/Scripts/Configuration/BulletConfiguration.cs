using UnityEngine;

namespace Configuration
{
    [CreateAssetMenu(fileName = "Bullet Entity Configuration", menuName = "Configuration/Game/Bullet Entity", order = 2)]
    public class BulletConfiguration : ScriptableObject
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _damage;

        public float Speed => _speed;
        public float Damage => _damage;
    }
}