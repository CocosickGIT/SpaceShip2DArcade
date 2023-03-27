using Api;
using UnityEngine;

namespace PowerUps
{
    public class ShieldLogic : MonoBehaviour
    {
        [SerializeField] private ShieldHealth _shieldHealth;
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (!col.CompareTag("Enemy")) return;
            
            var health = col.GetComponent<IHealth>();
            health.Damage(100);
            _shieldHealth.Damage(1);
        }
    }
}
