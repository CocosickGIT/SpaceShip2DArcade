using Managers;
using UnityEngine;

namespace PowerUps.Configs
{
    [CreateAssetMenu(menuName = "PowerUps/ShieldBuff")]
    public class ShieldBuff : PowerUpBase
    {
        [SerializeField] private SoundPlayer _shieldBuffSound;
        public override void Apply(GameObject target)
        {
            if (target.CompareTag("Player"))
            {
                _shieldBuffSound.Play();
                
                var controller = target.GetComponentInChildren<ShieldController>();
                controller.Active();
            }
        }
    }
}
