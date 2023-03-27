using System;
using Api;
using Managers;
using UnityEngine;

namespace Common
{
    public class Health : MonoBehaviour, IHealth
    {
    
        public event Action<int> OnHealthChanged;
        public event Action OnKilled;
        public event Action OnDestroyed;

        [SerializeField] private int _maxHealth;
        [SerializeField] private int _currentHealth;
        [SerializeField] private GameObject _effect;
        [SerializeField] private SoundPlayer _explosionSound;
        [SerializeField] private SoundPlayer _soundHit;
        
        public int MaxHealth => _maxHealth;
        public int CurrentHealth => _currentHealth;
        

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
                _explosionSound.Play();
                Instantiate(_effect, transform.position ,Quaternion.identity);
                Destroy(gameObject);
            }
        }

        public void Heal(int value)
        {
            OnHealthChanged?.Invoke(_currentHealth);
            if (_currentHealth != 0 && _currentHealth <= _maxHealth)
                _currentHealth += value;
        }
        
        public void OnDestroy()
        {
            OnDestroyed?.Invoke();
        }
    }
}
