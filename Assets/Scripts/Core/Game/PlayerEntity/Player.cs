using Core.Game.Controllers.Spawner;
using Services.Input;
using UnityEngine;

namespace Core.Game.PlayerEntity
{
    public class Player : MonoBehaviour
    {
        private IInputService _inputService;
        private IBulletSpawner _bulletSpawner;

        public void Construct(IBulletSpawner bulletSpawner, IInputService inputService)
        {
            _inputService = inputService;
            _bulletSpawner = bulletSpawner;
        }

        private void Update()
        {
            Vector3 screenToWorldPoint = Camera.main.ScreenToWorldPoint(_inputService.Position);
            screenToWorldPoint.z = 0.0f;
            Vector2 lookDirection = screenToWorldPoint - new Vector3(transform.position.x,transform.position.y);
            float angle =  Mathf.Atan2(lookDirection.y, lookDirection.x)* Mathf.Rad2Deg;
            transform.localEulerAngles = new Vector3(0,0, angle - 90.0f);

            if (_inputService.FireButtonClicked)
            {
                _bulletSpawner.SpawnBullet(transform.position, transform.up);
            }
        }
    }
}