using UnityEngine;
using UnityEngine.Audio;

namespace Menu
{
    public class MenuSound : MonoBehaviour
    {
        [SerializeField] private AudioMixerSnapshot _inGame;
        [SerializeField] private AudioMixerSnapshot _inMenu;

        [SerializeField] private GameMenu _gameMenu;

        private void Awake()
        {
            _gameMenu.OnGameTransition += InGameTransition;
            _gameMenu.OnMenuTransition += InMenuTransition;
        }

        private void InMenuTransition()
        {
            _inMenu.TransitionTo(0f);
        }

        private void InGameTransition()
        {
            _inGame.TransitionTo(0.5f);
        }

        private void OnDisable()
        {
            _gameMenu.OnMenuTransition -= InMenuTransition;
            _gameMenu.OnGameTransition -= InGameTransition;

        }
    }
}