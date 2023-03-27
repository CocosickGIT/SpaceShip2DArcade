using UnityEngine;
using Zenject;

namespace Boss
{
    public class BossSpawner : MonoBehaviour
    {

        [Inject] private DiContainer _diContainer = null;
        [SerializeField] private Transform _spawningContainer;
        [SerializeField] private GameObject _bossPrefab;

        private Transform _transform;

        private void Awake()
        {
            _transform = transform;
        }

        private void Start()
        {
            Spawn();
        }

        private void Spawn()
        {
            var position = _transform.position;
            var rotation = Quaternion.Euler(0, 0, 180);
            var boss = _diContainer.InstantiatePrefab(_bossPrefab,position, rotation,_spawningContainer);

            var health = boss.GetComponent<BossHealth>();
            
            SpawnManager.EnemyList.Add(boss.transform);
            health.OnDestroyed += () => SpawnManager.EnemyList.Remove(boss.transform);
        }
    }
}