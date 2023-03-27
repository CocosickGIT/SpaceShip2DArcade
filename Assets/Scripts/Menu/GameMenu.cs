using System;
using Api;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class GameMenu : MonoBehaviour
    {
        public event Action OnMenuTransition;
        public event Action OnGameTransition;
        
        [SerializeField] private GameObject _healthNScore;
        [SerializeField] private GameObject _pauseMenu;
        
        private void Awake()
        {
            _pauseMenu.SetActive(false);
            _healthNScore.SetActive(true);
        }
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (GameState.IsGamePaused)
                { 
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }

        public void Pause()
        {
            OnMenuTransition?.Invoke();
            
            GameState.IsGamePaused = true;
            Time.timeScale = 0f;

            _pauseMenu.SetActive(true);
            _healthNScore.SetActive(false);
        } 

        public void Resume()
        {
            OnGameTransition?.Invoke();
            
            GameState.IsGamePaused = false;
            Time.timeScale = 1f;
            
            _pauseMenu.SetActive(false);
            _healthNScore.SetActive(true);
            
        }

        public void Quit()
        {
            SceneManager.LoadScene("Menu");
            Time.timeScale = 1f;
        }
    }
}
