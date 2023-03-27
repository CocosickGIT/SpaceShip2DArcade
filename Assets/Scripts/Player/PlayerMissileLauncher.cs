using Api;
using UnityEngine;

namespace Player
{
    public class PlayerMissileLauncher : MonoBehaviour
    {
        [SerializeField] private GameObject _missile;
        [SerializeField] private Transform[] _firePoints;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.X) && !GameState.IsGamePaused)
                foreach (var firePoint in _firePoints)
                    Instantiate(_missile, firePoint.position, firePoint.rotation);
        }
    }
}