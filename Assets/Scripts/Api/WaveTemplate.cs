using System;
using System.Collections;
using Common;
using DG.Tweening;
using ModestTree;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Api
{
    public class WaveTemplate : MonoBehaviour
    {
        [SerializeField] private Health _playerHealth;
        [SerializeField] private GameObject _enemyWaveSpawner;
        [SerializeField] private GameObject _bossWaveSpawner;
        [SerializeField] private int _waveCount;
        [SerializeField] private Text _text; 

        private float _timer;
        private float _waveDuration = 10f;
        
        private void Start()
        {
           StartCoroutine(EnemyScenario(_enemyWaveSpawner,_waveDuration));
        }

        private void Update()
        {
            if (_playerHealth.CurrentHealth <= 0)
                StopAllCoroutines();
        }

        private IEnumerator EnemyScenario(GameObject waveType, float waveDuration)
        {
            for (int i = 1; i <= _waveCount; i++)
            {
                _text.text = "Wave " + i;
                StartCoroutine(FadeTextToZeroAlpha(2f, _text));

                WaveStart(waveType);
                yield return new WaitForSeconds(waveDuration);

                WaveEnd(waveType);
                yield return new WaitForSeconds(6);
                StopCoroutine(EnemyScenario(waveType, waveDuration));
            }
            _text.text = "Boss Wave"; 
            StartCoroutine(FadeTextToZeroAlpha(2f, _text));
            
            StartCoroutine(BossScenario(_bossWaveSpawner));
        }

        private IEnumerator BossScenario(GameObject waveType)
        {
            WaveStart(waveType);
            yield return new WaitForSeconds(3);
            
            WaveEnd(waveType);
        }

        private void WaveStart(GameObject wave)
        {
            wave.SetActive(true);
        }

        private void WaveEnd(GameObject wave)
        {
            wave.SetActive(false);
        }
        
        private IEnumerator FadeTextToZeroAlpha(float t, Text i)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
            while (i.color.a > 0.0f)
            {
                i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
                yield return null;
            }
        }
    }
    
}