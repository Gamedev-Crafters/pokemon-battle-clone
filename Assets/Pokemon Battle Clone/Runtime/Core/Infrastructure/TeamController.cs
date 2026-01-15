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
        
        public TeamController(bool isPlayer, Team team, TeamView view, Sprite debugSprite)
        {
            _isPlayer = isPlayer;
            _team = team;
            _view = view;
            _debugSprite = debugSprite;
        }

        public void Init()
        {
            var pokemon = _team.PokemonList[0];
            _view.SetStaticData(_debugSprite, pokemon.Name, pokemon.Stats.Level);
            _view.health.UpdateBar(pokemon.Health.Max, pokemon.Health.Current);
            
            if (_isPlayer)
                _view.moveSet.Display(pokemon.MoveSet);
        }
    }
}