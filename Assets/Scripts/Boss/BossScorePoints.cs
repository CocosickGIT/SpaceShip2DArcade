using Player;
using UnityEngine;
using Zenject;

namespace Boss
{
    public class BossScorePoints : MonoBehaviour
    {
        
        [Inject] private UIScore _uiScore;
    
        [SerializeField] private int _points;
        [SerializeField] private BossHealth _health;
    
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
