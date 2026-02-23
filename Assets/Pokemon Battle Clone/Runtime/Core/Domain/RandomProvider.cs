namespace Pokemon_Battle_Clone.Runtime.Core.Domain
{
    public static class RandomProvider
    {
        private static readonly System.Random _random = new System.Random();
        
        /// <summary>
        /// Returns a random integer that is within a specified range.
        /// </summary>
        /// <param name="min">The inclusive lower bound of the random number returned.</param>
        /// <param name="max">The exclusive upper bound of the random number returned. max must be greater than or equal to min.</param>
        /// <returns></returns>
        public static int Range(int min, int max) => _random.Next(min, max);
        
        /// <summary>
        /// Returns a random integer.
        /// </summary>
        /// <returns></returns>
        public static int Next() => _random.Next();
    }
}