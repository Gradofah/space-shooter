using Core.Game.Controllers;
using Core.Game.Controllers.Spawner;
using Core.Game.PlayerEntity;
using Services.Assets;
using Services.Input;
using UnityEngine;

namespace Services.Factory
{
    public class StandardGameFactory : IGameFactory
    {
        private readonly IAssetProvider _assetProvider;
        private readonly IBulletSpawner _bulletSpawner;
        private readonly IInputService _inputService;

        public StandardGameFactory(IAssetProvider assetProvider, IBulletSpawner bulletSpawner, IInputService inputService)
        {
            _assetProvider = assetProvider;
            _bulletSpawner = bulletSpawner;
            _inputService = inputService;
        }
        
        public void CreateBackground() => 
            Object.Instantiate(_assetProvider.GetBackgroundPrefab());

        public void CreatePlayer()
        {
            GameObject gameObject = Object.Instantiate(_assetProvider.GetPlayerPrefab());
            Player player = gameObject.GetComponent<Player>();
            player.Construct(_bulletSpawner, _inputService);
        }
    }
}