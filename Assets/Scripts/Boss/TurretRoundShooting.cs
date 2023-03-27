using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace Boss
{
    public class TurretRoundShooting : MonoBehaviour
    {
        [SerializeField] private GameObject _shooting;

        [SerializeField] private Vector3 _idleRotationPos = new (0,0,180);
        [SerializeField] private Vector3 _startRotationPos = new (0,0,120);
        [SerializeField] private Vector3 _endRotationPos = new (0,0,240);
        [SerializeField] private float _timeBetweenCycles = 10f;


        private Transform _transform;
        private float _timer;

        private void Awake()
        {
            _transform = transform;
            StartCoroutine(TurretRotating(_timeBetweenCycles));
        }

        private IEnumerator TurretRotating(float timeBetweenCycles)
        {
            if (_transform == null) yield break;
            
            var rotating = DOTween.Sequence();

            rotating.Append(_transform.DORotate(_startRotationPos, 2));
            yield return new DOTweenCYInstruction.WaitForCompletion(rotating);
            
            _shooting.SetActive(true);
            
            rotating = DOTween.Sequence();

            rotating.Append(_transform.DORotate(_endRotationPos, 6));
            yield return new DOTweenCYInstruction.WaitForCompletion(rotating);
            
            rotating = DOTween.Sequence();
            _shooting.SetActive(false);
            rotating.Append(_transform.DORotate( _idleRotationPos,2));
            
            yield return new DOTweenCYInstruction.WaitForCompletion(rotating);
            yield return new WaitForSeconds(timeBetweenCycles);
            yield return StartCoroutine(TurretRotating(timeBetweenCycles));
        }

        private void OnDestroy()
        {
            DOTween.KillAll();
        }
    }
}
