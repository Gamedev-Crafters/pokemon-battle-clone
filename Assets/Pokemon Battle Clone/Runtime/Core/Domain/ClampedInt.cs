using System;

namespace Pokemon_Battle_Clone.Runtime.Core.Domain
{
    public class ClampedInt
    {
        public int Min { get; }
        public int Max { get; }

        private int _value;

        public int Value
        {
            get => _value;
            set => _value = Math.Clamp(value, Min, Max);
        }

        public ClampedInt(int value, int min, int max)
        {
            Min = min;
            Max = max;
            _value = Math.Clamp(value, Min, Max);
        }

        public static implicit operator int(ClampedInt value) => value.Value;
    }
}