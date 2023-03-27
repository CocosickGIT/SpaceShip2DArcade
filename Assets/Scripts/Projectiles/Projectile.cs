using Api;
using Managers;
using UnityEngine;

namespace Projectiles
{
    public class Projectile : MonoBehaviour
    {
        [Header("Raycast")] 
        [SerializeField] private float _distance;
        [SerializeField] private int _damage;
        [SerializeField] private LayerMask _ignoreLayers;
        
        [SerializeField] private SoundPlayer _shootSound;
        

        private Transform _transform;

        private void Awake()
        {
            _transform = transform;
        }

        private void Start()
        {
            _shootSound.Play();
        }


        private void Update()
        {
            var hit2D = Physics2D.Raycast(
                _transform.position, _transform.up, _distance, ~_ignoreLayers);
            
            if (hit2D.collider != null)
            {
                var health = hit2D.collider.GetComponent<IHealth>();
                health.Damage(_damage);
                Destroy(gameObject);
            }
        }
        

        private void OnDrawGizmos()
        {
            var tr = transform;

            Gizmos.color = Color.red;
            Gizmos.DrawRay(tr.position, tr.up * _distance);
        }
    }
}
