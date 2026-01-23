using System.Threading.Tasks;
using Pokemon_Battle_Clone.Runtime.Core.Domain;
using Pokemon_Battle_Clone.Runtime.Moves.Domain;
using Pokemon_Battle_Clone.Runtime.Trainer.Domain;
using UnityEngine;

namespace Pokemon_Battle_Clone.Runtime.Core.Infrastructure
{
    public class TeamController
    {
        private readonly bool _isPlayer;
        private readonly Team _team;
        private readonly TeamView _view;
        
        private readonly Sprite _debugSprite;

        private TeamController _opponentTeamController;
        
        private TaskCompletionSource<TrainerAction> _actionTcs;

        public bool Defeated => _team.Defeated;
        
        public TeamController(bool isPlayer, Team team, TeamView view, Sprite debugSprite)
        {
            _isPlayer = isPlayer;
            _team = team;
            _view = view;
            _debugSprite = debugSprite;
            
            if (_isPlayer)
                _view.moveSet.OnMoveSelected += OnMoveSelected;
        }

        public void Init(TeamController opponentTeam)
        {
            _opponentTeamController = opponentTeam;
            
            _view.SetStaticData(_debugSprite, _team.FirstPokemon.Name, _team.FirstPokemon.Stats.Level);
            _view.health.SetHealth(_team.FirstPokemon.Health.Max, _team.FirstPokemon.Health.Current);
            
            if (_isPlayer)
                _view.moveSet.Display(_team.FirstPokemon.MoveSet);
        }

        public void Update()
        {
            _view.health.SetHealth(_team.FirstPokemon.Health.Max, _team.FirstPokemon.Health.Current);
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
            var userAnimator = _view.pokemon;
            var targetAnimator = _opponentTeamController._view.pokemon;

            await userAnimator.PlayAttackAnimation();
            move.Execute(user, target);

            if (target.Health.Current > 0)
                await targetAnimator.PlayHitAnimation();
            else
                await targetAnimator.PlayFaintAnimation();
        }

        private void OnMoveSelected(int index)
        {
            if (_actionTcs == null || _actionTcs.Task.IsCompleted)
                return;

            var move = _team.FirstPokemon.MoveSet.Moves[index];
            var action = new MoveAction(_isPlayer ? Side.Player : Side.Rival, _team.FirstPokemon.Stats.Speed, move, this);
            _actionTcs.SetResult(action);
        }
    }
}