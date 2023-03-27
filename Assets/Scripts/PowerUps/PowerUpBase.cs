using UnityEngine;

namespace PowerUps
{
    public abstract class PowerUpBase : ScriptableObject
    {
        public abstract void Apply(GameObject target);
    }
}
