using System;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Boss
{
    public class TurretLogic : MonoBehaviour
    {
        [SerializeField] private float _rotationStrength;
        
        // private Sequence _activeSequence;

        private Transform _player;
        private Transform _transform;
        private float _radiusAroundTarget = 2f;

        private Vector3 _sphere;
        private void Start()
        {
            var player = GameObject.FindGameObjectWithTag("Player");
            _player = player.GetComponent<Transform>();
            _transform = transform;
            
            // Rotation();
        }

        private void Update()
        {
            if (_player != null)
                FollowingTarget();
        }

        private void FollowingTarget()
        {
            var targetPosition = RandomPointAroundTarget();
            var currentPosition = _transform.position;
        
            var directionToEnemy = (targetPosition - currentPosition).normalized;
            var rotationAngle = Mathf.Atan2(directionToEnemy.y, directionToEnemy.x) * Mathf.Rad2Deg + 270f;

            var rotation = Quaternion.Euler(0, 0, rotationAngle);
            var rotationLerp = Quaternion.Lerp(_transform.rotation, rotation, _rotationStrength);
            
            _transform.rotation = rotationLerp;
        }
        private Vector3 RandomPointAroundTarget()
        {
            var randomSphere = Random.insideUnitSphere;
            randomSphere.z = 0;

            randomSphere = randomSphere.normalized * _radiusAroundTarget;
            randomSphere = _player.position + randomSphere;
        
            return randomSphere; 
        }

        // private void Rotation()
        // {
        //     var seq = DOTween.Sequence();
        //     _activeSequence = seq;
        //
        //     seq.AppendInterval(2f);
        //
        //     seq = DOTween.Sequence();
        //     seq.Append(_transform.DORotate(new Vector3(0, 0, 145), 3))
        //         .Append(_transform.DORotate(new Vector3(0, 0, -145), 3))
        //         .Append(_transform.DORotate(new Vector3(0, 0, 145), 3))
        //         .SetLoops(-1, LoopType.Yoyo)
        //         .SetTarget(gameObject);
        // }

        // private void OnDestroy()
        // {
        //     _activeSequence?.Kill();
        // }
        
    }
}
