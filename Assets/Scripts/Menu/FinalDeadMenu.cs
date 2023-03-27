using Api;
using Boss;
using Common;
using Player;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace Menu
{
    public class FinalDeadMenu : MonoBehaviour
    {
        [Inject] private UIScore _value;
        
        [SerializeField] private GameObject _finalScreen;
        [SerializeField] private Health _player;
        [SerializeField] private Text _scoreText;
        [SerializeField] private Text _finalText;

        private void Awake()
        {
            _finalScreen.SetActive(false);
        }

        private void Update()
        {
            if (_player.CurrentHealth <= 0)
            {
                DeadScreen();
            }
        }

        private void DeadScreen()
        {
            _finalScreen.SetActive(true);
            _scoreText.text = "Score: " + _value.ScoreValue;
            _finalText.text = "Game Over";
        }

        public void WinScreen()
        {
            _finalScreen.SetActive(true);
            _scoreText.text = "Score: " + _value.ScoreValue;
            _finalText.text = "You Win";
        }

        public void Restart()
        {
            SceneManager.LoadScene("Scenes/Game");
        }

        public void Quit()
        {
            SceneManager.LoadScene("Scenes/Menu");
        }
    }
}
