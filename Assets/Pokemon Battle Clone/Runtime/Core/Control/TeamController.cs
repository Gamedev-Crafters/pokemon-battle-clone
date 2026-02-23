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
        protected readonly Team Team;
        public TeamView View { get; }
        private readonly Dictionary<uint, Sprite> _sprites;

        public bool Defeated => Team.Defeated;
        public bool IsFirstPokemonDefeated => Team.FirstPokemon.Defeated;

        private Sprite FirstPokemonSprite => _sprites[Team.FirstPokemon.ID];

        protected TeamController(Team team, TeamView view, Dictionary<uint, Sprite> sprites)
        {
            Team = team;
            View = view;
            _sprites = new Dictionary<uint, Sprite>(sprites);
        }

        public async Task Init() => await SendFirstPokemon();

        public abstract Task<TrainerAction> SelectActionTask();

        public virtual async Task SendFirstPokemon()
        {
            await View.SendPokemon(Team.FirstPokemon, FirstPokemonSprite);
        }
    }
}