using UnityEngine;

namespace PowerUps
{
    public class FollowPosition : MonoBehaviour
    {
        public Vector3 TargetPosition { get; set; }
        [SerializeField] private float _moveSpeed = 2f;

        private Transform _transform;

        private void Awake()
        {
            _transform = transform;
        }

        private void Update()
        {
            _transform.position = Vector3.Lerp(_transform.position, TargetPosition, _moveSpeed * Time.deltaTime);
        }
    }
}