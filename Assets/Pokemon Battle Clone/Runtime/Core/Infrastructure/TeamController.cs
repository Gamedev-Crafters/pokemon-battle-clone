using Pokemon_Battle_Clone.Runtime.Core.Domain;
using UnityEngine;

namespace Pokemon_Battle_Clone.Runtime.Core.Infrastructure
{
    public class TeamController
    {
        private readonly Team _team;
        private readonly TeamView _view;
        
        private readonly Sprite _debugSprite;
        
        public TeamController(Team team, TeamView view, Sprite debugSprite)
        {
            _team = team;
            _view = view;
            _debugSprite = debugSprite;
        }

        public void Init()
        {
            var pokemon = _team.PokemonList[0];
            _view.SetStaticData(_debugSprite, pokemon.Name, pokemon.Stats.Level);
            _view.SetHealth(pokemon.Health.Max, pokemon.Health.Current);
        }
    }
}