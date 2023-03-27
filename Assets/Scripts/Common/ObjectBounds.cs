using UnityEngine;
using Zenject;

namespace Common
{
    public class ObjectBounds : MonoBehaviour
    {
        [Inject] private Camera _mainCamera;

        private Vector2 _screenBounds;
        private float _objectWidth;
        private float _objectHeight;

        private Transform _transform;
        private Transform _cameraTransform;

        private void Start()
        {
            _transform = transform;
            _cameraTransform = _mainCamera.transform;

            _objectWidth = _transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
            _objectHeight = _transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
        }

        private void Update()
        {
            _screenBounds = _mainCamera.ScreenToWorldPoint(
                new Vector3(Screen.width, Screen.height, _cameraTransform.position.z));
            var viewPos = _transform.position;
            viewPos.x = Mathf.Clamp(viewPos.x, _screenBounds.x * -1 + _objectWidth, _screenBounds.x - _objectWidth);
            viewPos.y = Mathf.Clamp(viewPos.y, _screenBounds.y * -1 + _objectHeight, _screenBounds.y - _objectHeight);
            _transform.position = viewPos;
        }
    }
}
