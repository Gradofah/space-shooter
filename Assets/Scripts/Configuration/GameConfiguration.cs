using UnityEngine;

namespace Configuration
{
    [CreateAssetMenu(fileName = "Game Configuration", menuName = "Configuration/Game/Game Configuration", order = 3)]
    public class GameConfiguration : ScriptableObject
    {
        [SerializeField] private float _playTime;

        public float PlayTime => _playTime;
    }
}