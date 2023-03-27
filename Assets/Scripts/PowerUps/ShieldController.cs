using System;
using UnityEngine;

namespace PowerUps
{
    public class ShieldController : MonoBehaviour
    {
        [SerializeField] private GameObject _shield;
        [SerializeField] private float _durability;
        [SerializeField] private ShieldHealth _shieldHealth;
        
        private bool _isActive = true;
        private float _timer;
        
        private void Awake()
        {
            if (_isActive)
            {
                _isActive = false;
                _shield.SetActive(false);
            }
        }

        private void Update()
        {
            if (!_isActive) return;
            
            _timer += Time.deltaTime;

            if (_timer >= _durability)
                Inactive();
        }
        
        public void Active()
        {   
            _timer = 0;
            _isActive = true;
            _shield.SetActive(true);
            _shieldHealth.Heal(5);
        }

        private void Inactive()
        {
            _timer = 0;
            _isActive = false;
            _shield.SetActive(false);
        }
    
    
    
    
    }
}
