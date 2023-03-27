using Common;
using Managers;
using UnityEngine;

namespace PowerUps.Configs
{
    [CreateAssetMenu(menuName = "PowerUps/HealBuff")]
    public class HealBuff : PowerUpBase
    {
        [SerializeField] private SoundPlayer _healthBuffSound;
        
        public override void Apply(GameObject target)
        {
            var health = target.GetComponent<Health>();
            
            if (target.CompareTag("Player"))
            {
                _healthBuffSound.Play();
                health.Heal(1);
            }
        }
    }
}