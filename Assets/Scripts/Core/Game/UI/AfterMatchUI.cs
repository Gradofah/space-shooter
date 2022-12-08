using UnityEngine;
using UnityEngine.UI;

namespace Core.Game.UI
{
    public class AfterMatchUI : MonoBehaviour
    {
        [SerializeField] private Button _restartButton;
        [SerializeField] private GameObject _winText;
        [SerializeField] private GameObject _loseText;

        public Button RestartButton => _restartButton;
        public GameObject WinText => _winText;
        public GameObject LoseText => _loseText;
    }
}