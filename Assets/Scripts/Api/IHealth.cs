using System;

namespace Api
{
   public interface IHealth
   {
      event Action<int> OnHealthChanged;
      event Action OnKilled;
      event Action OnDestroyed;
   
      int MaxHealth { get; }
      int CurrentHealth { get; }

      void Damage(int value);
      void Heal(int value);
   }
}
