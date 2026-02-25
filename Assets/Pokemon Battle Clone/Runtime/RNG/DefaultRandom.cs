namespace Pokemon_Battle_Clone.Runtime.RNG
{
    public class DefaultRandom : IRandom
    {
        private readonly System.Random _random;

        public DefaultRandom(int? seed = null)
        {
            _random = seed.HasValue
                ? new System.Random(seed.Value)
                : new System.Random();
        }
        
        public int Range(int min, int max) => _random.Next(min, max);

        public int Next() => _random.Next();

        public bool Roll(int chancePercent)
        {
            if (chancePercent <= 0) return false;
            if (chancePercent >= 100) return true;
         
            return _random.Next(0, 100) < chancePercent;
        }
    }
}