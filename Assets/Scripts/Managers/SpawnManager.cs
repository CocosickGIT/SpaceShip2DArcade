using System.Collections.Generic;
using Api;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    public static readonly List<Transform> EnemyList = new ();
    
    [Inject] private DiContainer _diContainer = null;
    [Inject] private Camera _camera;

    [SerializeField] private Transform _spawningContainer;
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private float _timeToSpawn;
    [SerializeField] private float _distance;
    [SerializeField] private float _distanceRatio = 7f;

    
    private float _timer;
    private Transform _transform;
    
    private void Awake()
    {
        _transform = transform;
        EnemyList.Clear();
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _timeToSpawn)
        {
            Spawn();
            _timer = 0;
        }
    }

    private void Spawn()
    {
        _distance = _camera.aspect * _distanceRatio;
        
        var randomPoints = Random.Range(-_distance, _distance);
        var rotation = Quaternion.Euler(0,0,180);
        var spawnPoints = new Vector3(randomPoints, _transform.position.y, 0);

        var enemy = _diContainer.InstantiatePrefab(_enemyPrefab, spawnPoints, rotation, _spawningContainer);
        
        var health = enemy.GetComponent<IHealth>();
        EnemyList.Add(enemy.transform);
        health.OnDestroyed += () => EnemyList.Remove(enemy.transform);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, Vector3.right * _distance);
        Gizmos.DrawRay(transform.position, Vector3.left * _distance);
    }
}
