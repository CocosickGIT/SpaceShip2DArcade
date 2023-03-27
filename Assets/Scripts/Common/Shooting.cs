using UnityEngine;

namespace Common
{
    public class Shooting : MonoBehaviour
    {
        [SerializeField] private GameObject _projectilePrefab;
        [SerializeField] private Transform[] _firePoints;
        [SerializeField] private float _timeBetweenShoot = 1.5f;
        
        private float _timer;

        private void Update()
        {
            if (_firePoints != null) 
                TurretShooting(_timeBetweenShoot);
        }

        private void TurretShooting(float shootingTime)
        {
            _timer += Time.deltaTime;
            
            if (_timer >= shootingTime)
            {
                foreach (var spawnPoint in _firePoints)
                    Instantiate(_projectilePrefab, spawnPoint.position, spawnPoint.rotation);
                
                _timer = 0;
            }
            
        }
    }
}
