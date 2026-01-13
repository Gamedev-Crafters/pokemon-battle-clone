using System;

namespace Pokemon_Battle_Clone.Runtime.Core
{
    public class Health
    {
        public int Max { get; }
        public int Current { get; private set; }

        public void Damage(int amount) => Current = Math.Clamp(Current - amount, 0, Max);
        public void Recover(int amount) => Current = Math.Clamp(Current + amount, 0, Max);

        public Health(int max)
        {
            Max = max;
        }
    }
}