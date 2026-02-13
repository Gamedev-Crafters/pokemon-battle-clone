using System;

namespace Pokemon_Battle_Clone.Runtime.Core.Domain
{
    public class Health
    {
        public int Max { get; }

        public int Current
        {
            get => _current;
            private set
            {
                _current = value;
                OnChanged.Invoke(this);
            }
        }

        private int _current;

        public event Action<Health> OnChanged = delegate { };

        public Health(int max)
        {
            Max = max;
            Current = Max;
        }

        public void Damage(int amount) => Current = Math.Clamp(Current - amount, 0, Max);
        public void Recover(int amount) => Current = Math.Clamp(Current + amount, 0, Max);
    }
}