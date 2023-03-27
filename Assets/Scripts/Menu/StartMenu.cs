using Api;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;


namespace Menu
{
    public class StartMenu : MonoBehaviour
    {
        [SerializeField] private AudioMixerSnapshot _inGame;
        private void Awake()
        {
            GameState.IsGamePaused = true;
        }

        public void Play()
        {
            _inGame.TransitionTo(1f);
            SceneManager.LoadScene("Game");
            GameState.IsGamePaused = false;
        }
            
        public void Quit()
        {
            Application.Quit();
#if UNITY_EDITOR
            UnityEditor.EditorApplication.ExitPlaymode(); 
#endif
        }
    }
}