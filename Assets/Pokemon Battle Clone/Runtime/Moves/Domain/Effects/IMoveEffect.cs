using Pokemon_Battle_Clone.Runtime.Core.Domain;
using Pokemon_Battle_Clone.Runtime.RNG;

namespace Pokemon_Battle_Clone.Runtime.Moves.Domain.Effects
{
    public interface IMoveEffect
    {
        void Apply(Move move, Pokemon user, Pokemon target, IRandom random);
    }
}