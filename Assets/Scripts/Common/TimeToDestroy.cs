using UnityEngine;

namespace Common
{
    public class TimeToDestroy : MonoBehaviour
    {
        [SerializeField] private float _destroyTime;

        private float _timer;
    
        void Update()
        {
            _timer += Time.deltaTime;

            if (_timer >= _destroyTime)
            {
                Destroy(gameObject);
                _timer = 0;
            }
        }
    }
}
