using System;
using Api;
using Managers;
using UnityEngine;

namespace PowerUps
{
    public class ShieldHealth : MonoBehaviour, IHealth

    {
        public event Action<int> OnHealthChanged;
        public event Action OnKilled;
        public event Action OnDestroyed;
        [SerializeField] private int _maxHealth;
        [SerializeField] private int _currentHealth;
        [SerializeField] private SoundPlayer _soundHit;
        
        public int MaxHealth => _maxHealth;
        public int CurrentHealth
        {
            get => _currentHealth;
            set => _currentHealth = value;
        }

        private void Awake()
        {
            _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);
        }
        public void Damage(int value)
        {
            _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);
            _currentHealth -= value;
            _soundHit.Play();
            OnHealthChanged?.Invoke(CurrentHealth);

            if (_currentHealth <= 0)
            {
                OnKilled?.Invoke();
                gameObject.SetActive(false);
            }
        }

        public void Heal(int value)
        {
            _currentHealth = value;
        }

        public void OnDestroy()
        {
            OnDestroyed?.Invoke();
        }
    }
}