using System;
using Core.Game.EnemyEntity.EnemyBehaviour.DirectionBehaviour;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Core.Game.EnemyEntity
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private CollisionObserver _collisionObserver;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private GameObject _body;

        private float _speed;
        private float _health;

        private float _defaultSpeed;
        private float _defaultHealth;

        private Vector3 _currentDirection;

        public event Action<Enemy> OnDied;
        public event Action OnAfterDeath;

        private IDirectionBehaviour _directionBehaviour;

        private void OnEnable() => 
            _collisionObserver.OnCollisionEnter += ChangeDirection;

        private void OnDisable() => 
            _collisionObserver.OnCollisionEnter -= ChangeDirection;

        private void LateUpdate()
        {
            ControlSpeed();
            ControlRotation();
        }

        public void DealDamage(float damage)
        {
            _health -= damage;

            if (_health <= 0)
            {
                OnDied?.Invoke(this);
                OnAfterDeath?.Invoke();
            }
        }

        public void Force()
        {
            Vector3 direction = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0.0f).normalized;
            _currentDirection = direction;
            _rigidbody2D.AddForce(direction * _speed, ForceMode2D.Force);
        }

        public void ResetToDefault()
        {
            _speed = _defaultSpeed;
            _health = _defaultHealth;
        }

        public void SetSpeed(float value)
        {
            _defaultSpeed = value;
            _speed = value;
        }

        public void SetHealth(float value)
        {
            _defaultHealth = value;
            _health = value;
        }

        public void SetSprite(Sprite sprite) => 
            _spriteRenderer.sprite = sprite;

        public void SetPosition(Vector2 position) => 
            transform.position = position;

        public void SetBodySize(Vector3 size) => 
            _body.transform.localScale = size;

        public void SetDirectionBehaviour(IDirectionBehaviour behaviour) => 
            _directionBehaviour = behaviour;

        private void ChangeDirection(Collision2D obj) => 
            _directionBehaviour
                .ChangeDirection(ref _currentDirection, ref _rigidbody2D, ref obj, ref _speed);

        private void ControlRotation() => 
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);

        private void ControlSpeed()
        {
            float speed = _rigidbody2D.velocity.magnitude;
            _rigidbody2D.velocity = _currentDirection.normalized * Mathf.Max(speed, _speed);
        }
    }
}