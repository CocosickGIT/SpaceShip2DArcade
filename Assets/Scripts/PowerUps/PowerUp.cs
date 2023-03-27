using UnityEngine;

namespace PowerUps
{
    public class PowerUp : MonoBehaviour
    { 
        [SerializeField] private PowerUpBase _powerUp;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            _powerUp.Apply(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
