using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Common.Loot
{
    public class Loot : MonoBehaviour

    {
        [SerializeField] private List<GameObject> _loot;
        [SerializeField] private int[] _weightValue;
        
        private int TotalValue => _weightValue.Sum();

        private void Drop()
        {
            var dropValue = Random.Range(0, TotalValue);

            Debug.Log(dropValue);
            for (int i = 0; i < _loot.Count; i++)
            {
                if (dropValue <= _weightValue[i]) 
                {
                    Debug.Log(_weightValue[i]);
                    Instantiate(_loot[i]);
                    break;
                }
                else
                {
                    dropValue -= _weightValue[i];
                }
            }
        }
    }
}
