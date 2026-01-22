using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pokemon_Battle_Clone.Runtime.Core.Domain;
using Pokemon_Battle_Clone.Runtime.Moves.Domain.Effects;
using UnityEngine.Assertions;

namespace Pokemon_Battle_Clone.Runtime.Moves.Domain
{
    public enum MoveCategory
    {
        Physical, Special, Status
    }
    
    public class Move
    {
        public string Name { get; }
        public ElementalType Type { get; }
        public MoveCategory Category { get; }
        public ClampedInt PP { get; private set; }
        public int Accuracy { get; }
        public int Power { get; }
        public int Priority { get; }

        private readonly List<IMoveEffect> _effects = new List<IMoveEffect>();

        public Move(string name, ElementalType type, MoveCategory category, int pp, int accuracy, int power, int priority)
        {
            if (pp < 0)
                throw new ArgumentOutOfRangeException(nameof(pp), "PP must be greater or equal than 0");
            if (accuracy < 0)
                throw new ArgumentOutOfRangeException(nameof(accuracy), "Accuracy must be greater or equal than 0");
            if (power < 0)
                throw new ArgumentOutOfRangeException(nameof(power), "Power must be greater or equal than 0");
            if (priority < 0)
                throw new ArgumentOutOfRangeException(nameof(priority), "Priority must be greater or equal than 0");
            
            Name = name;
            Type = type;
            Category = category;
            PP = new ClampedInt(pp, 0, pp);
            Accuracy = accuracy;
            Power = power;
            Priority = priority;
        }

        public void AddEffects(IEnumerable<IMoveEffect> effects)
        {
            foreach (var effect in effects)
                AddEffect(effect);
        }
        
        public void AddEffect(IMoveEffect effect) => _effects.Add(effect);
        
        public void Execute(Pokemon user, Pokemon target)
        {
            Assert.IsTrue(PP > 0);
            PP.Value--;
            
            foreach (var effect in _effects)
                effect.Apply(this, user, target);
        }
    }
}