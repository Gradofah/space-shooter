using UnityEngine;

namespace Services.Assets
{
    public class ResourcesAssetProvider : IAssetProvider
    {
        private const string MainMenuPrefabPath = "Prefabs/MainMenu/UI/MainMenuCanvas";
        private const string EnemyPrefabPath = "Prefabs/Game/Enemy";
        private const string BackgroundPrefabPath = "Prefabs/Game/Background";
        private const string BulletPrefabPath = "Prefabs/Game/Bullet";
        private const string PlayerPrefabPath = "Prefabs/Game/Player";
        private const string AfterScreenPrefabPath = "Prefabs/MainMenu/UI/AfterMatchCanvas";


        public GameObject GetMainMenuPrefab() => 
            Resources.Load<GameObject>(MainMenuPrefabPath);

        public GameObject GetEnemyPrefab() => 
            Resources.Load<GameObject>(EnemyPrefabPath);

        public GameObject GetBackgroundPrefab() => 
            Resources.Load<GameObject>(BackgroundPrefabPath);

        public GameObject GetBulletPrefab() => 
            Resources.Load<GameObject>(BulletPrefabPath);

        public GameObject GetPlayerPrefab() => 
            Resources.Load<GameObject>(PlayerPrefabPath);

        public GameObject GetAfterScreenPrefab() => 
            Resources.Load<GameObject>(AfterScreenPrefabPath);
    }
}