using System.Collections.Generic;
using Pokemon_Battle_Clone.Runtime.Core.Domain;
using Pokemon_Battle_Clone.Runtime.Moves.Domain;
using Pokemon_Battle_Clone.Runtime.Moves.Domain.Effects;
using Pokemon_Battle_Clone.Runtime.Stats.Domain;

namespace Pokemon_Battle_Clone.Runtime.Builders
{
    public class MoveBuilder : IBuilder<Move>
    {
        private string _name = "???";
        private ElementalType _type = ElementalType.None;
        private MoveCategory _category = MoveCategory.Status;
        private int _pp;
        private int _accuracy = 100;
        private int _power;
        private readonly List<IMoveEffect> _effects = new List<IMoveEffect>();

        public MoveBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public MoveBuilder WithType(ElementalType type)
        {
            _type = type;
            return this;
        }

        public MoveBuilder WithCategory(MoveCategory category)
        {
            _category = category;
            return this;
        }

        public MoveBuilder WithPP(int pp)
        {
            _pp = pp;
            return this;
        }

        public MoveBuilder WithAccuracy(int accuracy)
        {
            _accuracy = accuracy;
            return this;
        }

        public MoveBuilder WithPower(int power)
        {
            _power = power;
            if (_power > 0)
                _effects.Add(new DamageEffect());
            return this;
        }

        public MoveBuilder WithStatsModifier(bool applyToTarget, StatSet statsModifier)
        {
            _effects.Add(new StatsModifierEffect(applyToTarget, statsModifier));
            return this;
        }
        
        public Move Build()
        {
            var move = new Move(_name, _type, _category, _pp, _accuracy, _power);
            move.AddEffects(_effects);
            return move;
        }

        public static implicit operator Move(MoveBuilder builder) => builder.Build();
    }
}