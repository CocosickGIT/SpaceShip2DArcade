using System;
using Common;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace PowerUps
{
    public class PowerUpSpawn : MonoBehaviour
    {
        [SerializeField, Range(0,100)] private float _dropRate;
        [SerializeField] private Health _health;
        [SerializeField] private float _targetPositionRadius;
        [SerializeField] private List<ItemData> _items;

        private int _totalValue;

        private void Awake()
        {
            _health.OnKilled += Drop;
            _totalValue = _items.Select(x => x.DropChance).Sum();
        }

        private void Drop()
        {
            var dropValue = Random.Range(0, _totalValue);
            
            var random = Random.value;
            if (_dropRate / 100f >= random)
            {
                for (int i = 0; i < _items.Count; i++)
                {
                    if (dropValue <= _items[i].DropChance)
                    {
                        var buff = Instantiate(_items[i].PowerUpPrefab, transform.position, Quaternion.identity);
                        buff.TargetPosition = RandomPoint();
                        break;
                    }

                    dropValue -= _items[i].DropChance;
                }
            }
            _health.OnKilled -= Drop;
        }

        private Vector3 RandomPoint()
        {
            var randomSphere = Random.insideUnitSphere;
            randomSphere.z = 0;

            randomSphere = randomSphere.normalized * _targetPositionRadius;
            randomSphere = transform.position + randomSphere;
        
            return randomSphere;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _targetPositionRadius);
        }
    }

    [Serializable]
    public class ItemData
    {
        public FollowPosition PowerUpPrefab;
        public int DropChance;
    }
}