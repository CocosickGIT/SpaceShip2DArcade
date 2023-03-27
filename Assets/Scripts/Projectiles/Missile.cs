using Common;
using UnityEngine;
using Api;

namespace Projectiles
{
    public class Missile : MonoBehaviour
    {
        [SerializeField] private Movement _movement;
        [SerializeField] private float _rotationStrength;
        [SerializeField] private AnimationCurve _speedCurve;
        [SerializeField] private float _detectionRadius = 10f;

        private Transform _transform;
       
        private void Awake()
        {
            _transform = transform;
        }

        private void Update()
        {
            if (GameState.IsGamePaused == false)
                TowardsEnemy();
            
            LockOnEnemy();
        }

        private void TowardsEnemy()
        {
            var enemy = LockOnEnemy();
            if (enemy == null)
                return;
        
            var enemyPosition = enemy.position;
            var currentPosition = _transform.position;
        
            var directionToEnemy = (enemyPosition - currentPosition).normalized;
            var rotationAngle = Mathf.Atan2(directionToEnemy.y, directionToEnemy.x) * Mathf.Rad2Deg + 270f;

            var rotation = Quaternion.Euler(0, 0, rotationAngle);
            var rotationLerp = Quaternion.Lerp(_transform.rotation, rotation, _rotationStrength);
        
            _transform.rotation = rotationLerp;

            var rocketForward = _transform.up;
            var normalizedAngle = Vector3.Angle(rocketForward, directionToEnemy) / 180f; // 0..1

            _movement.SpeedMultiplier = _speedCurve.Evaluate(normalizedAngle);
        }
    
        private Transform LockOnEnemy()
        {
            var enemyList = SpawnManager.EnemyList;

            Transform closestTarget = null;
        
            var minimalDistance = _detectionRadius;
        
            if (enemyList != null)
            {
                foreach (var enemy in enemyList)
                {
                    var distance = Vector3.Distance(enemy.position, _transform.position);
                    if (distance < minimalDistance)
                    {
                        closestTarget = enemy;
                        minimalDistance = distance;
                    }
                }
            }
            return closestTarget;
        }
    }
}