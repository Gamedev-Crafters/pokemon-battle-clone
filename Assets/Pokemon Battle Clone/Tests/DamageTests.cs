using NUnit.Framework;
using Pokemon_Battle_Clone.Runtime.Core.Domain;

namespace Pokemon_Battle_Clone.Tests
{
    public class DamageTests
    {
        [Test]
        public void AttackDamage()
        {
            var damage = PokemonUtils.CalculateDamage(level: 75, attack: 123, defense: 163, power: 65, targets: 1f,
                weather: 1f, critical: 1f, random: PokemonUtils.RandomDamageFactor(), stab: 1.5f, effectiveness: 4f,
                burn: 1f, other: 1f);
            
            Assert.That(damage, Is.InRange(170, 200));
        }
    }
}