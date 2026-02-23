using System.Collections.Generic;
using System.Threading.Tasks;
using Pokemon_Battle_Clone.Runtime.Core.Domain;
using Pokemon_Battle_Clone.Runtime.Core.Infrastructure;
using Pokemon_Battle_Clone.Runtime.Trainer.Domain;
using UnityEngine;

namespace Pokemon_Battle_Clone.Runtime.Core.Control
{
    public class PlayerTeamController : TeamController
    {
        public PlayerTeamController(Team team, TeamView view, Dictionary<uint, Sprite> sprites)
            : base(team, view, sprites)
        {
            View.actionsHUD.moveSetView.OnMoveSelected += OnMoveSelected;
            View.actionsHUD.pokemonSelector.OnPokemonSelected += OnPokemonSelected;
        }

        public override Task<TrainerAction> SelectActionTask()
        {
            _actionTcs = new TaskCompletionSource<TrainerAction>();
            return _actionTcs.Task;
        }

        public override async Task SendFirstPokemon()
        {
            await base.SendFirstPokemon();
            
            View.actionsHUD.SetData(_team, _team.FirstPokemon.MoveSet);
            View.actionsHUD.HideActions();
        }

        private void OnMoveSelected(int index)
        {
            if (_actionTcs == null || _actionTcs.Task.IsCompleted)
                return;

            var move = _team.FirstPokemon.MoveSet.Moves[index];
            var action = new MoveAction(Side.Player, _team.FirstPokemon.Stats.Speed, move);
            _actionTcs.SetResult(action);
        }

        private void OnPokemonSelected(int index)
        {
            if (_actionTcs == null || _actionTcs.Task.IsCompleted)
                return;

            var action = new SwapPokemonAction(Side.Player, _team.FirstPokemon.Stats.Speed, index);
            _actionTcs.SetResult(action);
        }
    }
}