using Pokemon_Battle_Clone.Runtime.Battles.Domain;
using Pokemon_Battle_Clone.Runtime.Battles.Domain.Events;
using Pokemon_Battle_Clone.Runtime.Core.Domain;
using Pokemon_Battle_Clone.Runtime.RNG;

namespace Pokemon_Battle_Clone.Runtime.Moves.Domain.Effects
{
    public interface IMoveEffect
    {
        IBattleEvent Apply(Move move, Battle battle, Side side);
    }
}