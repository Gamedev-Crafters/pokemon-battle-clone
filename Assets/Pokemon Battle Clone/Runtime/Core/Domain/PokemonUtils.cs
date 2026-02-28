using System;
using Pokemon_Battle_Clone.Runtime.RNG;

namespace Pokemon_Battle_Clone.Runtime.Core.Domain
{
    //¿Qué es PokemonUtils
    public static class PokemonUtils
    {
        //Métodos con tantos parámetros son dificiles de leer y entender, ¿se te ocurre algo para facilitar que se entienda mejor?
        public static int CalculateDamage(int level, int attack, int defense, int power, float targets, float weather, float critical, float random, float stab, float effectiveness, float burn, float other)
        {
            var damage = ( ( 2 * level / 5f + 2 ) * power * attack / defense / 50 + 2 ) * targets * weather * critical * random * stab * effectiveness * burn * other;
            return Math.Max(1, (int)damage);
        }

        public static float RandomDamageFactor(IRandom random) => random.Range(85, 101) / 100f;
    }
}