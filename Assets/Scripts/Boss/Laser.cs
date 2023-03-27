using Common;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Boss
{
    public class Laser : MonoBehaviour
    {
        [SerializeField] private Transform _playerTransform;
        [SerializeField] private Transform _turretTransform;
        [SerializeField] private GameObject _laserPrefab;

        [SerializeField] private float _radiusAroundTarget;




        private void LaunchLaser()
        {
            
        }
        
        private Vector3 RandomPointAroundTarget()
        {
            var randomSphere = Random.insideUnitSphere;
            randomSphere.z = 0;

            randomSphere = randomSphere.normalized * _radiusAroundTarget;
            randomSphere = transform.position + randomSphere;
        
            return randomSphere; 
        }
    }
}