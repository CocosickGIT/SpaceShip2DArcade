using System;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Common.Loot
{
    public class LootWithTiers : MonoBehaviour

    {
        [SerializeField] private int[] _tiers;
        [SerializeField] private float[] _weights;
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.N))
                Debug.Log(LootWeights(_tiers, _weights));
        }

        private int LootWeights(int[] tiers, float[] weights)
        {
            var totalWeight = weights.Sum();

            var point = Random.Range(0, totalWeight);
            float currentTotal = 0;

            for (var i = 0; i < weights.Length; i++)
            {
                currentTotal += weights[i];
                if (point < currentTotal) 
                    return tiers[i];
            }
            return 0;
        }
    }
}