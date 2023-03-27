using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace Boss
{
    public class BossAI : MonoBehaviour
    {
        private Sequence _activeSequence;
        private Transform _transform;
        
        private void Awake()
        {
            if (transform != null)
                _transform = transform;
        }

        private void Start()
        {
            StartCoroutine(IntroSequence());
        }

        private IEnumerator IntroSequence()
        {
            if (_transform == null) yield return null;
            
            var sequence = DOTween.Sequence();
            _activeSequence = sequence;

            sequence.Append(_transform.DOMoveY(5, 2));
            
            // yield return new DOTweenCYInstruction.WaitForCompletion(sequence);
            // _activeSequence?.Kill();
            yield return null;
        }
    } 
}