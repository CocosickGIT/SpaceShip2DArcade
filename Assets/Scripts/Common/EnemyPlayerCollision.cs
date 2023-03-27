using Api;
using UnityEngine;

namespace Common
{
    public class EnemyPlayerCollision : MonoBehaviour
    {
        [SerializeField] private int _damage;
        public void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Player"))
            {
                if (col.TryGetComponent<IHealth>(out var health))
                    health.Damage(_damage);

                if (TryGetComponent<IHealth>(out var eHealth))
                    eHealth.Damage(50);
            }
        }
    }
}