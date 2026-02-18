using System.Threading.Tasks;
using Pokemon_Battle_Clone.Runtime.Core.Control;
using Pokemon_Battle_Clone.Runtime.Core.Domain;
using Pokemon_Battle_Clone.Runtime.Moves.Domain;

namespace Pokemon_Battle_Clone.Runtime.Trainer.Domain
{
    public class MoveAction : TrainerAction
    {
        public override int Priority { get; }

        private readonly Move _move;
        private readonly TeamController _userTeamController;

        public MoveAction(Side side, int pokemonInFieldSpeed, Move move, TeamController userTeamController)
            : base(side, pokemonInFieldSpeed)
        {
            _move = move;
            _userTeamController = userTeamController;

            Priority = move.Priority;
        }
        
        public override async Task Execute(Battle battle)
        {
            // await _userTeamController.PerformMove(_move);
            var user = battle.GetTeam(Side).FirstPokemon;
            var target = battle.GetOpponentTeam(Side).FirstPokemon;
            
            _move.Execute(user, target);
        }
    }
}