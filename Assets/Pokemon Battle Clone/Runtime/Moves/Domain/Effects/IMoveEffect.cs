using System.Collections.Generic;
using Pokemon_Battle_Clone.Runtime.Battles.Domain;
using Pokemon_Battle_Clone.Runtime.Battles.Domain.Events;

namespace Pokemon_Battle_Clone.Runtime.Moves.Domain.Effects
{
    public interface IMoveEffect
    {
        IList<IBattleEvent> Apply(Move move, Battle battle, Side side);
    }
}