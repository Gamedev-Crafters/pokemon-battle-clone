using Pokemon_Battle_Clone.Runtime.Builders;
using Pokemon_Battle_Clone.Runtime.Stats.Domain;

namespace Pokemon_Battle_Clone.Runtime.Core.Domain
{
    public static class PokemonFactory
    {
        public static Pokemon Totodile()
        {
            return A.Pokemon.WithName("Totodile")
                .WithLevel(50)
                .WithBaseStats(new StatSet(hp: 50, attack: 65, defense: 64, spcAttack: 44, spcDefense: 48, speed: 43))
                .WithTypes(ElementalType.Water)
                .WithNature(Nature.Adamant())
                .WithIVs(new StatSet(31, 31, 31, 31, 31, 31))
                .WithEVs(new StatSet(hp: 6, attack: 252, defense: 0, spcAttack: 0, spcDefense: 0, speed: 252));
        }

        public static Pokemon Pidgey()
        {
            return A.Pokemon.WithName("Pidgey")
                .WithLevel(50)
                .WithBaseStats(new StatSet(hp: 40, attack: 45, defense: 40, spcAttack: 35, spcDefense: 35, speed: 56))
                .WithTypes(ElementalType.Flying, ElementalType.Normal)
                .WithNature(Nature.Adamant())
                .WithIVs(new StatSet(31, 31, 31, 31, 31, 31))
                .WithEVs(new StatSet(hp: 6, attack: 252, defense: 0, spcAttack: 0, spcDefense: 0, speed: 252));
        }
    }
}