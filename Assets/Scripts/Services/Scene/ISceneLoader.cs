using System;
using Infrastructure.Locator;

namespace Services.Scene
{
    public interface ISceneLoader : IService
    {
        void LoadSceneAsync(string sceneName, Action onComplete = null);
    }
}