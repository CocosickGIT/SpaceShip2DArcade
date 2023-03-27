using UnityEngine;

namespace Common
{
    public class Movement : MonoBehaviour
    {
        public float SpeedMultiplier = 1;
        [SerializeField] public float Speed;
        [SerializeField] private Vector3 _direction;

        private Transform _transform;

        private void Awake()
        {
            _transform = transform;
        }

        private void Update()
        {
            _transform.position += _transform.TransformDirection(_direction * (Speed * SpeedMultiplier * Time.deltaTime));
        }
    }
}
