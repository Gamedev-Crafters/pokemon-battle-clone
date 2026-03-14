using System.Collections.Generic;
using Pokemon_Battle_Clone.Runtime.Battles.Domain;
using Pokemon_Battle_Clone.Runtime.Battles.Domain.Events;
using Pokemon_Battle_Clone.Runtime.Core.Domain;
using UnityEngine;

namespace Pokemon_Battle_Clone.Runtime.Moves.Domain.Effects
{
    [System.Serializable]
    public class DamageAndRecoverEffect : DamageTypeEffect
    {
        [SerializeField] private int _recoverPercentage;

        public DamageAndRecoverEffect(int recoverPercentage)
        {
            _recoverPercentage = recoverPercentage;
        }
        
        public override IList<IBattleEvent> Apply(Move move, Battle battle, Side side)
        {
            var user = battle.GetFirstPokemon(side);
            var target = battle.GetFirstPokemon(side.Opposite());
            var damage = GetDamage(move, battle, side);
            var regainedHealth = damage * _recoverPercentage / 100;
            
            target.Health.Damage(damage);
            user.Health.Recover(regainedHealth);
            
            return new List<IBattleEvent>
            {
                new DamageEvent(
                    side: side,
                    targetHealth: target.Health,
                    userName: battle.GetFirstPokemon(side).Name,
                    targetName: target.Name,
                    effectiveness: move.Type.EffectivenessAgainst(target.Type1, target.Type2)
                ),
                new RecoverHealthEvent(user.Name, user.Health, side)
            };
        }
    }
}