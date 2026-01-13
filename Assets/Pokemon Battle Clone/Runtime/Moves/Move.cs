using System.Collections.Generic;
using Pokemon_Battle_Clone.Runtime.Core;
using Pokemon_Battle_Clone.Runtime.Moves.Effects;
using UnityEngine.Assertions;

namespace Pokemon_Battle_Clone.Runtime.Moves
{
    public enum MoveCategory
    {
        Physical, Special, Status
    }
    
    public class Move
    {
        public ElementalType Type { get; }
        public MoveCategory Category { get; }
        public int PP { get; private set; }
        public int Accuracy { get; }
        public int Power { get; }

        private readonly List<IMoveEffect> _effects = new List<IMoveEffect>();

        public Move(ElementalType type, MoveCategory category, int pp, int accuracy, int power)
        {
            Type = type;
            Category = category;
            PP = pp;
            Accuracy = accuracy;
            Power = power;
        }
        
        public void AddEffect(IMoveEffect effect) => _effects.Add(effect);
        
        public void Execute(Pokemon user, Pokemon target)
        {
            Assert.IsTrue(PP > 0);
            
            foreach (var effect in _effects)
                effect.Apply(this, user, target);

            PP--;
        }
    }
}