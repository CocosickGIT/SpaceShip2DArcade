using Api;
using UnityEngine;

namespace Player
{
    public class PlayerShooting : MonoBehaviour
    {
        [SerializeField] private GameObject _projectilePrefab;
        [SerializeField] private GameObject _launchEffect;
        [SerializeField] private Transform[] _firePoints;
        [SerializeField] private float _timeBetweenShoot;

        private float _timer;
        private Transform _transform;

        private void Awake() => _transform = transform;
        
        private void Update()
        {
            _timer += Time.deltaTime;
        
            var shoot = Input.GetKey(KeyCode.Space) && !GameState.IsGamePaused;
            var time = _timer >= _timeBetweenShoot;
        
            if(shoot && time)
            {
                for (int i = 0; i < _firePoints.Length; i++)
                {
                    var rotation = _transform.rotation;
                    Instantiate(_projectilePrefab, _firePoints[i].position, rotation);
                    Instantiate(_launchEffect, _firePoints[i].position, rotation);
                }
                _timer = 0;
            }
        }
    }
}
