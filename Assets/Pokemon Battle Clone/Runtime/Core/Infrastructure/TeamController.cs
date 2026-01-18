using System.Threading.Tasks;
using Pokemon_Battle_Clone.Runtime.Core.Domain;
using Pokemon_Battle_Clone.Runtime.Moves;
using UnityEngine;

namespace Pokemon_Battle_Clone.Runtime.Core.Infrastructure
{
    public class TeamController
    {
        private readonly bool _isPlayer;
        private readonly Team _team;
        private readonly TeamView _view;
        
        private readonly Sprite _debugSprite;

        private TaskCompletionSource<int> _actionTcs;
        
        public TeamController(bool isPlayer, Team team, TeamView view, Sprite debugSprite)
        {
            _isPlayer = isPlayer;
            _team = team;
            _view = view;
            _debugSprite = debugSprite;
            
            if (_isPlayer)
                _view.moveSet.OnMoveSelected += OnMoveSelected;
        }

        public void Init()
        {
            var pokemon = _team.PokemonList[0];
            _view.SetStaticData(_debugSprite, pokemon.Name, pokemon.Stats.Level);
            _view.health.UpdateBar(pokemon.Health.Max, pokemon.Health.Current);
            
            if (_isPlayer)
                _view.moveSet.Display(pokemon.MoveSet);
        }

        public void Update()
        {
            _view.health.UpdateBar(_team.PokemonList[0].Health.Max, _team.PokemonList[0].Health.Current);
        }

        public Task<int> WaitForAction()
        {
            _actionTcs = new TaskCompletionSource<int>();
            return _actionTcs.Task;
        }

        public void PerformMove(int index, TeamController rivalTeam)
        {
            var user = _team.PokemonList[0];
            user.MoveSet.ExecuteMove(index, user, rivalTeam._team.PokemonList[0]);
        }

        private void OnMoveSelected(int index)
        {
            if (_actionTcs == null || _actionTcs.Task.IsCompleted)
                return;
            
            _actionTcs.SetResult(index);
        }
    }
}