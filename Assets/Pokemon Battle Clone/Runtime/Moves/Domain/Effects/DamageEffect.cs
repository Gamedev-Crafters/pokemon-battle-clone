using System.Collections.Generic;
using Pokemon_Battle_Clone.Runtime.Battles.Domain;
using Pokemon_Battle_Clone.Runtime.Battles.Domain.Events;
using Pokemon_Battle_Clone.Runtime.Core.Domain;

namespace Pokemon_Battle_Clone.Runtime.Moves.Domain.Effects
{
    [System.Serializable]
    public class DamageEffect : DamageTypeEffect
    {
        public override IList<IBattleEvent> Apply(Move move, Battle battle, Side side)
        {
            var damage = GetDamage(move, battle, side);
            
            var target = battle.GetFirstPokemon(side.Opposite());
            target.Health.Damage(damage);

            return new List<IBattleEvent>
            {
                new DamageEvent(
                    side: side,
                    targetHealth: target.Health,
                    userName: battle.GetFirstPokemon(side).Name,
                    targetName: target.Name,
                    effectiveness: move.Type.EffectivenessAgainst(target.Type1, target.Type2)
                )
            };
        }
    }
}