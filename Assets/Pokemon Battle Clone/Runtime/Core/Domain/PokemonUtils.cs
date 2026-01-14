using System;

namespace Pokemon_Battle_Clone.Runtime.Core.Domain
{
    public static class PokemonUtils
    {
        private static readonly Random rnd = new Random();
        
        public static int CalculateDamage(int level, int attack, int defense, int power, float targets, float weather, float critical, float random, float stab, float effectiveness, float burn, float other)
        {
            var damage = ( ( 2 * level / 5f + 2 ) * power * attack / defense / 50 + 2 ) * targets * weather * critical * random * stab * effectiveness * burn * other;
            return Math.Max(1, (int)damage);
        }

        public static float RandomDamageFactor() => rnd.Next(85, 101) / 100f;
    }
}