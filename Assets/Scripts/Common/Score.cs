using Player;
using UnityEngine;
using Zenject;

namespace Common
{
    public class Score : MonoBehaviour
    {
        [Inject] private UIScore _uiScore;
    
        [SerializeField] private int _points;
        [SerializeField] private Health _health;
    
        private void Awake()
        {
            _health.OnKilled += AddScore;
        }

        private void AddScore()
        {
            _uiScore.ScoreCount(_points);
            _health.OnKilled -= AddScore;
        }
    }
}