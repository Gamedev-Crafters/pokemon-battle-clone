using Pokemon_Battle_Clone.Runtime.Core;

namespace Pokemon_Battle_Clone.Runtime.Moves.Effects
{
    public class DamageEffect : IMoveEffect
    {
        public void Apply(Move move, Pokemon user, Pokemon target)
        {
            var damage = GetDamage(move, user, target);
            target.Health.Damage(damage);
        }

        private int GetDamage(Move move, Pokemon user, Pokemon target)
        {
            var level = user.Stats.Level;
            var attack = user.Stats.GetAttackByCategory(move.Category);
            var defense = user.Stats.GetDefenseByCategory(move.Category);
            var power = move.Power;
            var targets = 1f;
            var weather = 1f;
            var critical = 1f;
            var random = PokemonUtils.RandomDamageFactor();
            var stab = user.STAB(move.Type);
            var effectiveness = move.Type.EffectivenessAgainst(target.Type1, target.Type2);
            var burn = 1f;
            var other = 1f;

            return PokemonUtils.CalculateDamage(level, attack, defense, power, targets, weather, critical, random, stab,
                effectiveness, burn, other);
        }
    }
}