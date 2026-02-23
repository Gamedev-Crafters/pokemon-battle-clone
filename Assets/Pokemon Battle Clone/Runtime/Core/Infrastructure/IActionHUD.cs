using System;
using Pokemon_Battle_Clone.Runtime.Core.Domain;
using Pokemon_Battle_Clone.Runtime.Moves.Domain;

namespace Pokemon_Battle_Clone.Runtime.Core.Infrastructure
{
    public interface IActionHUD
    {
        void HideActions();
        void SetData(Team team, MoveSet moveSet);

        void RegisterMoveSelectedListener(Action<int> listener);
        void RegisterPokemonSelectedListener(Action<int> listener);
    }
}