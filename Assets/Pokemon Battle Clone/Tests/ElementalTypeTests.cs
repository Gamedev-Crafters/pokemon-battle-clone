using NUnit.Framework;
using Pokemon_Battle_Clone.Runtime.Core;

namespace Pokemon_Battle_Clone.Tests
{
    public class ElementalTypeTests
    {
        [Test]
        public void NeutralAgainstMoveType()
        {
            var moveType = ElementalType.Fire;
            var pokemonType = ElementalType.Dark;
            
            Assert.That(moveType.EffectivenessAgainst(pokemonType), Is.EqualTo(1f));
        }

        [Test]
        public void WeakAgainstMoveType()
        {
            var moveType = ElementalType.Grass;
            var pokemonType = ElementalType.Water;
            
            Assert.That(moveType.EffectivenessAgainst(pokemonType), Is.EqualTo(2f));
        }

        [Test]
        public void ResistanceAgainstMoveType()
        {
            var moveType = ElementalType.Grass;
            var pokemonType = ElementalType.Fire;
            
            Assert.That(moveType.EffectivenessAgainst(pokemonType), Is.EqualTo(0.5f));
        }

        [Test]
        public void NeutralizeMoveEffectiveness()
        {
            var moveType = ElementalType.Water;
            var pokemonType1 = ElementalType.Grass;
            var pokemonType2 = ElementalType.Fire;
            
            Assert.That(moveType.EffectivenessAgainst(pokemonType1, pokemonType2), Is.EqualTo(1f));
        }

        [Test]
        public void IncreaseMoveEffectiveness()
        {
            var moveType = ElementalType.Water;
            var pokemonType1 = ElementalType.Ground;
            var pokemonType2 = ElementalType.Rock;
            
            Assert.That(moveType.EffectivenessAgainst(pokemonType1, pokemonType2), Is.EqualTo(4f));
        }

        [Test]
        public void ImmuniseMoveEffectiveness()
        {
            var moveType = ElementalType.Psychic;
            var pokemonType1 = ElementalType.Poison;
            var pokemonType2 = ElementalType.Dark;
            
            Assert.That(moveType.EffectivenessAgainst(pokemonType1, pokemonType2), Is.EqualTo(0f));
        }
    }
}