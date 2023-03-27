using System;
using DG.Tweening;
using UnityEngine;
using Zenject;

namespace Common
{
    public class CameraShaking : MonoBehaviour

    {
        [Inject] private Camera _camera;
        
        [SerializeField] private Health _health;
        [SerializeField] private float _duration = 0.25f;
        [SerializeField] private float _strength = 0.25f;
        [SerializeField] private float _transitionToCenter;
        
        private Transform _cameraTransform;
        private readonly Vector3 _defaultPosition = new (0,0,-50);
        private Sequence _sequence;
        private void Awake()
        {
            _health.OnKilled += Shake;
            _cameraTransform = _camera.transform;
        }

        private void Shake()
        {
            _sequence = DOTween.Sequence();
            _sequence.Append(_camera.DOShakePosition(_duration, _strength));
            _sequence.Append(_cameraTransform.DOMove(_defaultPosition, _transitionToCenter));
            _health.OnKilled -= Shake;
        }
    }
}