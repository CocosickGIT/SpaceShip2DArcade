using System;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _rotation;

        private Transform _transform;

        private void Awake()
        {
            _transform = transform;
        } 

        private void Update()
        {
            Movement();
            Rotation();
        }

        private void Movement()
        {
            var verticalMove = Input.GetAxis("Vertical");
            var horizontalMove = Input.GetAxis("Horizontal");

            var direction = new Vector3(horizontalMove, verticalMove, 0);
        
            _transform.position += _transform.TransformDirection(direction * (_speed * Time.deltaTime));
        }
        private void Rotation()
        {
            var angle = new Vector3(0, 0, _rotation);
        
            if (Input.GetKey(KeyCode.E))
                _transform.Rotate(-angle);

            if (Input.GetKey(KeyCode.Q))
                _transform.Rotate(angle);
        }
    }
}
