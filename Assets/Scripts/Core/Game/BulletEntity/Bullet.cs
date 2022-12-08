using System;
using Core.Game.EnemyEntity;
using UnityEngine;

namespace Core.Game.BulletEntity
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private CollisionObserver _collisionObserver;
        [SerializeField] private Rigidbody2D _rigidbody2D;

        private float _speed;
        private float _damage;
        
        private Vector3 _currentDirection;

        public event Action<Bullet> OnCollideWithEnemy;
        public event Action<Bullet> OnCollideWithSomething;

        private void OnEnable() => 
            _collisionObserver.OnCollisionEnter += CollideWithEnemy;

        private void OnDisable() => 
            _collisionObserver.OnCollisionEnter -= CollideWithEnemy;
        
        private void LateUpdate()
        {
            ControlSpeed();
            ControlRotation();
        }

        public void Force(Vector3 direction)
        {
            _currentDirection = direction;
            _rigidbody2D.AddForce(direction * _speed, ForceMode2D.Force);
        }

        public void SetDamage(float value) => 
            _damage = value;

        public void SetSpeed(float value) => 
            _speed = value;

        private void CollideWithEnemy(Collision2D obj)
        {
            if (obj.gameObject.TryGetComponent(out Enemy enemy))
            {
                enemy.DealDamage(_damage);
                OnCollideWithEnemy?.Invoke(this);
            }
            else
            {
                OnCollideWithSomething?.Invoke(this);
            }
        }

        private void ControlRotation() => 
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);

        private void ControlSpeed()
        {
            float speed = _rigidbody2D.velocity.magnitude;
            _rigidbody2D.velocity = _currentDirection.normalized * Mathf.Max(speed, _speed);
        }

        public void SetPosition(Vector3 position) => 
            transform.position = position;
    }
}