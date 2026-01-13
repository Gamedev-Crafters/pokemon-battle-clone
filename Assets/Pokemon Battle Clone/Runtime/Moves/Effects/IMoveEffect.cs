using Pokemon_Battle_Clone.Runtime.Core;

namespace Pokemon_Battle_Clone.Runtime.Moves.Effects
{
    public interface IMoveEffect
    {
        void Apply(Move move, Pokemon user, Pokemon target);
    }
}