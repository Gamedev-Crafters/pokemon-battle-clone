using NUnit.Framework;
using Pokemon_Battle_Clone.Runtime.Core.Domain;
using Pokemon_Battle_Clone.Runtime.RNG;

namespace Pokemon_Battle_Clone.Tests
{
    public class DamageTests
    {
        [Test]
        public void AttackDamage()
        {
            var randomFactor = PokemonUtils.RandomDamageFactor(new DefaultRandom());
            var damage = PokemonUtils.CalculateDamage(level: 75, attack: 123, defense: 163, power: 65, targets: 1f,
                weather: 1f, critical: 1f, random: randomFactor, stab: 1.5f, effectiveness: 4f,
                burn: 1f, other: 1f);
            
            Assert.That(damage, Is.InRange(170, 200));
        }
    }
}