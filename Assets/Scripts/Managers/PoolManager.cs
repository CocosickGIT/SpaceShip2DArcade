using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Pool;
using Random = UnityEngine.Random;

namespace Managers
{
    [DefaultExecutionOrder(-9)]
    public class PoolManager : MonoBehaviour
    {
        [SerializeField] private AudioSource _sound;
        
        public static ObjectPool<AudioSource> SoundPool;

        private void Awake()
        {
            SoundPool = new ObjectPool<AudioSource>(
                createFunc: () => Instantiate(_sound),
                actionOnGet: (obj) => obj.gameObject.SetActive(true),
                actionOnRelease: (obj) => obj.gameObject.SetActive(false),
                actionOnDestroy: Destroy,
                collectionCheck: false,
                defaultCapacity: 50,
                maxSize: 100);
        }
    }
    [Serializable]
    public class SoundPlayer
    {
        [SerializeField] private AudioClip[] _clips;
        [SerializeField] private Vector2 _randomVolume;
        [SerializeField] private Vector2 _randomPitch;
        [SerializeField] private AudioMixerGroup _audioMixer;

        public void Play()
        {
            if (PoolManager.SoundPool == null ) return;
           
            PoolManager.SoundPool.Get(out var audioSource);
            audioSource.clip = _clips[Random.Range(0, _clips.Length)];
            audioSource.volume = Random.Range(_randomVolume.x,_randomVolume.y);
            audioSource.pitch = Random.Range(_randomPitch.x,_randomPitch.y);
            audioSource.outputAudioMixerGroup = _audioMixer;
            
            audioSource.Play();
            DOVirtual.DelayedCall(_clips.Length + 0.1f, () => PoolManager.SoundPool.Release(audioSource));
        }
    }
}
