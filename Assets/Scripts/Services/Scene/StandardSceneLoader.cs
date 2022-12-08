using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Services.Scene
{
    public class StandardSceneLoader : ISceneLoader
    {
        public void LoadSceneAsync(string sceneName, Action onComplete = null)
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
            operation.completed += _ => onComplete?.Invoke();
        }
    }
}