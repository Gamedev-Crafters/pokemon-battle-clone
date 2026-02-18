using System.Collections.Generic;
using System.Threading.Tasks;
using Pokemon_Battle_Clone.Runtime.Core.Domain;
using Pokemon_Battle_Clone.Runtime.Core.Infrastructure;
using Pokemon_Battle_Clone.Runtime.Moves.Domain;
using Pokemon_Battle_Clone.Runtime.Trainer.Domain;
using UnityEngine;

namespace Pokemon_Battle_Clone.Runtime.Core.Control
{
    public class TeamController
    {
        private readonly bool _isPlayer;
        private readonly Team _team;
        private readonly TeamView _view;
        private readonly Dictionary<uint, Sprite> _sprites;
        
        private TeamController _opponentTeamController;
        
        private TaskCompletionSource<TrainerAction> _actionTcs;

        public bool Defeated => _team.Defeated;
        public bool IsFirstPokemonDefeated => _team.FirstPokemon.Defeated;
        
        private Sprite FirstPokemonSprite => _sprites[_team.FirstPokemon.ID];
        
        public TeamController(bool isPlayer, Team team, TeamView view, Dictionary<uint, Sprite> sprites)
        {
            _isPlayer = isPlayer;
            _team = team;
            _view = view;
            _sprites = new Dictionary<uint, Sprite>(sprites);
            
            if (_isPlayer)
            {
                _view.actionsHUD.moveSetView.OnMoveSelected += OnMoveSelected;
                _view.actionsHUD.pokemonSelector.OnPokemonSelected += OnPokemonSelected;
            }
        }

        public async Task Init(TeamController opponentTeam)
        {
            _opponentTeamController = opponentTeam;

            await _view.SendPokemon(_team.FirstPokemon, FirstPokemonSprite);
            _view.healthView.SetHealth(_team.FirstPokemon.Health.Max, _team.FirstPokemon.Health.Current);
            
            if (_isPlayer)
                _view.actionsHUD.SetData(_team, _team.FirstPokemon.MoveSet);
        }

        public Task<TrainerAction> SelectActionTask()
        {
            _actionTcs = new TaskCompletionSource<TrainerAction>();
            
            if (!_isPlayer)
                OnMoveSelected(0);
            
            return _actionTcs.Task;
        }

        public async Task PerformMove(Move move)
        {
            var user = _team.FirstPokemon;
            var target = _opponentTeamController._team.FirstPokemon;

            await _view.PlayAttackAnimation();
            move.Execute(user, target);

            if (target.Defeated)
                await _opponentTeamController._view.PlayFaintAnimation();
            else
                await _opponentTeamController._view.PlayHitAnimation();
        }

        public async Task SwapPokemon(int index)
        {
            _team.SwapPokemon(0, index);

            await _view.SendPokemon(_team.FirstPokemon, FirstPokemonSprite);
            _view.healthView.SetHealth(_team.FirstPokemon.Health.Max, _team.FirstPokemon.Health.Current);
            
            if (_isPlayer)
            {
                _view.actionsHUD.SetData(_team, _team.FirstPokemon.MoveSet);
                _view.actionsHUD.HideActions();
            }
        }

        private void OnMoveSelected(int index)
        {
            if (_actionTcs == null || _actionTcs.Task.IsCompleted)
                return;

            var move = _team.FirstPokemon.MoveSet.Moves[index];
            var action = new MoveAction(_isPlayer ? Side.Player : Side.Rival, _team.FirstPokemon.Stats.Speed, move);
            _actionTcs.SetResult(action);
        }

        private void OnPokemonSelected(int index)
        {
            if (_actionTcs == null || _actionTcs.Task.IsCompleted)
                return;

            var action = new SwapPokemonAction(_isPlayer ? Side.Player : Side.Rival, _team.FirstPokemon.Stats.Speed,
                index);
            _actionTcs.SetResult(action);
        }
    }
}