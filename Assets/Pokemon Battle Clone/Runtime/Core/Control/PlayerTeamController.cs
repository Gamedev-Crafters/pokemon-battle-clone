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
        private readonly IActionHUD _actionsHUD;
        private TaskCompletionSource<TrainerAction> _actionTcs;
        
        public PlayerTeamController(Team team, Dictionary<uint, Sprite> sprites, ITeamView view, IActionHUD actionsHUD)
            : base(team, view, sprites)
        {
            _actionsHUD = actionsHUD;
            
            _actionsHUD.RegisterMoveSelectedListener(OnMoveSelected);
            _actionsHUD.RegisterPokemonSelectedListener(OnPokemonSelected);
        }

        public override Task<TrainerAction> SelectActionTask()
        {
            _actionTcs = new TaskCompletionSource<TrainerAction>();
            return _actionTcs.Task;
        }

        public override async Task SendFirstPokemon()
        {
            await base.SendFirstPokemon();
            
            _actionsHUD.SetData(Team, Team.FirstPokemon.MoveSet);
            _actionsHUD.Hide();
        }

        private void OnMoveSelected(int index)
        {
            if (_actionTcs == null || _actionTcs.Task.IsCompleted)
                return;

            _actionsHUD.Hide();
            
            var move = Team.FirstPokemon.MoveSet.Moves[index];
            var action = new MoveAction(Side.Player, Team.FirstPokemon.Stats.Speed, move);
            _actionTcs.SetResult(action);
        }

        private void OnPokemonSelected(int index)
        {
            if (_actionTcs == null || _actionTcs.Task.IsCompleted)
                return;

            _actionsHUD.Hide();
            
            var action = new SwapPokemonAction(Side.Player, Team.FirstPokemon.Stats.Speed, index);
            _actionTcs.SetResult(action);
        }
    }
}