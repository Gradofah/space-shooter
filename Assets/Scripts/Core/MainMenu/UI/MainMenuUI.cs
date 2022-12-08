using UnityEngine;
using UnityEngine.UI;

namespace Core.MainMenu.UI
{
    public class MainMenuUI : MonoBehaviour
    {
        [SerializeField] private Button playButton;

        public Button PlayButton => playButton;
    }
}