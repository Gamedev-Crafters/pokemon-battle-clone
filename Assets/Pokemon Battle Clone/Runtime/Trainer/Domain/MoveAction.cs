using Pokemon_Battle_Clone.Runtime.Core.Domain;
using Pokemon_Battle_Clone.Runtime.Moves.Domain;

namespace Pokemon_Battle_Clone.Runtime.Trainer.Domain
{
    public class MoveAction : TrainerAction
    {
        public override int Priority { get; }

        private readonly Move _move;

        public MoveAction(Side side, int pokemonInFieldSpeed, Move move)
            : base(side, pokemonInFieldSpeed)
        {
            _move = move;

            Priority = move.Priority;
        }
        
        public override TrainerActionResult Execute(Battle battle)
        {
            var user = battle.GetTeam(Side).FirstPokemon;
            var target = battle.GetOpponentTeam(Side).FirstPokemon;

            var targetInitialHealth = target.Health.Current;
            
            _move.Execute(user, target);

            return new MoveResult
            {
                Side = Side,
                RivalFainted = target.Defeated,
                RivalDamaged = targetInitialHealth > target.Health.Current,
            };
        }
    }
}