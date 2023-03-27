using UnityEngine;

namespace Player
{
    public class BackgroundMovement : MonoBehaviour
    {
        [SerializeField] private Transform _background;
        [SerializeField] private Transform _target;
        [SerializeField] private float _lerp = 0.001f;

        private Vector3 _defaultPosition;
        
        private void Start()
        {
            _defaultPosition = _background.position;
        } 

        private void Update()
        {
            if (_target != null)
                _background.position = Vector3.Lerp(_defaultPosition, -_target.position, _lerp);
        }
    }
}
