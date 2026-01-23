namespace Pokemon_Battle_Clone.Runtime.Core.Domain
{
    public static class RandomProvider
    {
        private static readonly System.Random _random = new System.Random();
        
        public static int Range(int min, int max) => _random.Next(min, max);
        public static int Next() => _random.Next();
    }
}