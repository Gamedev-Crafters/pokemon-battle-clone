using System.Collections.Generic;
using System.Threading.Tasks;
using Pokemon_Battle_Clone.Runtime.Core.Domain;
using Pokemon_Battle_Clone.Runtime.Core.Infrastructure;
using Pokemon_Battle_Clone.Runtime.Trainer.Domain;
using UnityEngine;

namespace Pokemon_Battle_Clone.Runtime.Core.Control
{
    public class RivalTeamController : TeamController
    {
        public RivalTeamController(Team team, Dictionary<uint, Sprite> sprites, ITeamView view)
            : base(team, view, sprites) { }

        public override Task<TrainerAction> SelectActionTask()
        {
            var move = Team.FirstPokemon.MoveSet.Moves[0];
            var action = new MoveAction(Side.Rival, Team.FirstPokemon.Stats.Speed, move);

            return Task.FromResult<TrainerAction>(action);
        }

        public override Task<T> SelectActionOfType<T>(bool forceSelection)
        {
            throw new System.NotImplementedException();
        }
    }
}