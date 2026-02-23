using System.Collections.Generic;
using System.Threading.Tasks;
using Pokemon_Battle_Clone.Runtime.Core.Domain;
using Pokemon_Battle_Clone.Runtime.Core.Infrastructure;
using Pokemon_Battle_Clone.Runtime.Trainer.Domain;
using UnityEngine;

namespace Pokemon_Battle_Clone.Runtime.Core.Control
{
    public abstract class TeamController
    {
        protected readonly Team _team;
        public TeamView View { get; }
        protected readonly Dictionary<uint, Sprite> _sprites;
        
        protected TaskCompletionSource<TrainerAction> _actionTcs;

        public bool Defeated => _team.Defeated;
        public bool IsFirstPokemonDefeated => _team.FirstPokemon.Defeated;
        
        protected Sprite FirstPokemonSprite => _sprites[_team.FirstPokemon.ID];
        
        public TeamController(Team team, TeamView view, Dictionary<uint, Sprite> sprites)
        {
            _team = team;
            View = view;
            _sprites = new Dictionary<uint, Sprite>(sprites);
            
            // if (_isPlayer)
            // {
            //     View.actionsHUD.moveSetView.OnMoveSelected += OnMoveSelected;
            //     View.actionsHUD.pokemonSelector.OnPokemonSelected += OnPokemonSelected;
            // }
        }

        public async Task Init() => await SendFirstPokemon();

        public abstract Task<TrainerAction> SelectActionTask();
        
        // public Task<TrainerAction> SelectActionTask()
        // {
        //     _actionTcs = new TaskCompletionSource<TrainerAction>();
        //     
        //     if (!_isPlayer)
        //         OnMoveSelected(0);
        //     
        //     return _actionTcs.Task;
        // }

        public virtual async Task SendFirstPokemon()
        {
            await View.SendPokemon(_team.FirstPokemon, FirstPokemonSprite);
            
            // if (_isPlayer)
            // {
            //     View.actionsHUD.SetData(_team, _team.FirstPokemon.MoveSet);
            //     View.actionsHUD.HideActions();
            // }
        }

        // private void OnMoveSelected(int index)
        // {
        //     if (_actionTcs == null || _actionTcs.Task.IsCompleted)
        //         return;
        //
        //     var move = _team.FirstPokemon.MoveSet.Moves[index];
        //     var action = new MoveAction(_isPlayer ? Side.Player : Side.Rival, _team.FirstPokemon.Stats.Speed, move);
        //     _actionTcs.SetResult(action);
        // }

        // private void OnPokemonSelected(int index)
        // {
        //     if (_actionTcs == null || _actionTcs.Task.IsCompleted)
        //         return;
        //
        //     var action = new SwapPokemonAction(_isPlayer ? Side.Player : Side.Rival, _team.FirstPokemon.Stats.Speed,
        //         index);
        //     _actionTcs.SetResult(action);
        // }
    }
}