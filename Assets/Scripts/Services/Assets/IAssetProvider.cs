using Infrastructure.Locator;
using UnityEngine;

namespace Services.Assets
{
    public interface IAssetProvider : IService
    {
        GameObject GetMainMenuPrefab();
        GameObject GetEnemyPrefab();
        GameObject GetBackgroundPrefab();
        GameObject GetBulletPrefab();
        GameObject GetPlayerPrefab();
        GameObject GetAfterScreenPrefab();
    }
}