using System.Collections.Generic;
using Pokemon_Battle_Clone.Runtime.Core.Domain;
using Pokemon_Battle_Clone.Runtime.Moves.Domain.Effects;
using Pokemon_Battle_Clone.Runtime.RNG;
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

        public Move(string name, ElementalType type, MoveCategory category, uint pp, uint accuracy, uint power, int priority)
        {
            Name = name;
            Type = type;
            Category = category;
            PP = new ClampedInt((int)pp, 0, (int)pp);
            Accuracy = (int)accuracy;
            Power = (int)power;
            Priority = priority;
        }

        public void AddEffects(IEnumerable<IMoveEffect> effects)
        {
            foreach (var effect in effects)
                AddEffect(effect);
        }
        
        public void AddEffect(IMoveEffect effect) => _effects.Add(effect);
        
        public void Execute(Pokemon user, Pokemon target, IRandom random)
        {
            Assert.IsTrue(PP > 0);
            PP.Value--;
            
            foreach (var effect in _effects)
                effect.Apply(this, user, target, random);
        }
    }
}