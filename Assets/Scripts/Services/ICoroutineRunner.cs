using System.Collections;
using Infrastructure.Locator;
using UnityEngine;

namespace Services
{
    public interface ICoroutineRunner : IService
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
        void StopCoroutine(Coroutine coroutine);
    }
}