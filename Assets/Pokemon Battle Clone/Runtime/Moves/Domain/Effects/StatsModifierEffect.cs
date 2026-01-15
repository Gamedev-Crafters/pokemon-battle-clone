using Pokemon_Battle_Clone.Runtime.Core.Domain;
using Pokemon_Battle_Clone.Runtime.Stats.Domain;

namespace Pokemon_Battle_Clone.Runtime.Moves.Domain.Effects
{
    public class StatsModifierEffect : IMoveEffect
    {
        private readonly bool _applyToTarget;
        private readonly StatSet _statsModifier;

        public StatsModifierEffect(bool applyToTarget, StatSet statsModifier)
        {
            _applyToTarget = applyToTarget;
            _statsModifier = statsModifier;
        }
        
        public void Apply(Move move, Pokemon user, Pokemon target)
        {
            if (_applyToTarget)
                target.Stats.Modifiers.Apply(_statsModifier);
            else
                user.Stats.Modifiers.Apply(_statsModifier);
        }
    }
}