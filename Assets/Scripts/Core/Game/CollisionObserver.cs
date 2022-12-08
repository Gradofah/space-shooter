using System;
using UnityEngine;

namespace Core.Game
{
    public class CollisionObserver : MonoBehaviour
    {
        public event Action<Collision2D> OnCollisionEnter;
        
        private void OnCollisionEnter2D(Collision2D col)
        {
            OnCollisionEnter?.Invoke(col);
        }
    }
}