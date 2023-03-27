using Common;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class PlayerHealthView : MonoBehaviour
    {
        [SerializeField] private Health _health;
        [SerializeField] private Image[] _healthImage;

        private void OnEnable()
        {
            _health.OnHealthChanged += HealthView;
        }

        private void OnDisable()
        {
            _health.OnHealthChanged -= HealthView;
        }
        
        private void Update()
        {
            HealthView(_health.CurrentHealth);
        }

        private void HealthView(int health)
        {
            for (int i = 0; i < _healthImage.Length; i++)
                _healthImage[i].enabled = i < health;
        }
    }
}
