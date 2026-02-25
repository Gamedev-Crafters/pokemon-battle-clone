using Pokemon_Battle_Clone.Runtime.Core.Domain;
using Pokemon_Battle_Clone.Runtime.RNG;

namespace Pokemon_Battle_Clone.Runtime.Moves.Domain.Effects
{
    public class DamageEffect : IMoveEffect
    {
        public void Apply(Move move, Pokemon user, Pokemon target, IRandom random)
        {
            var damage = GetDamage(move, user, target, random);
            target.Health.Damage(damage);
        }

        private int GetDamage(Move move, Pokemon user, Pokemon target, IRandom random)
        {
            var level = user.Stats.Level;
            var attack = user.Stats.GetAttackByCategory(move.Category);
            var defense = target.Stats.GetDefenseByCategory(move.Category);
            var power = move.Power;
            var targets = 1f;
            var weather = 1f;
            var critical = 1f;
            var randomFactor = PokemonUtils.RandomDamageFactor(random);
            var stab = user.STAB(move.Type);
            var effectiveness = move.Type.EffectivenessAgainst(target.Type1, target.Type2);
            var burn = 1f;
            var other = 1f;

            return PokemonUtils.CalculateDamage(level, attack, defense, power, targets, weather, critical, randomFactor, stab,
                effectiveness, burn, other);
        }
    }
}