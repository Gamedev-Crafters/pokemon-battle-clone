using Pokemon_Battle_Clone.Runtime.Moves;

namespace Pokemon_Battle_Clone.Runtime.Core
{
    public class Pokemon
    {
        public ElementalType Type1 { get; private set; }
        public ElementalType Type2 { get; private set; }
        public StatsData Stats { get; private set; }
        public MoveSet MoveSet { get; private set; }

        public float STAB(ElementalType moveType)
        {
            if (moveType == Type1 || moveType == Type2)
                return 1.5f;
            return 1f;
        }

        public void Damage(int damage) => Stats.Health -= damage;
    }
}