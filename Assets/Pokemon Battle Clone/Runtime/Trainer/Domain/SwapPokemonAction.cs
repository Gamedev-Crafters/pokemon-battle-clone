using System.Threading.Tasks;
using Pokemon_Battle_Clone.Runtime.Core.Control;
using Pokemon_Battle_Clone.Runtime.Core.Domain;

namespace Pokemon_Battle_Clone.Runtime.Trainer.Domain
{
    public class SwapPokemonAction : TrainerAction
    {
        public override int Priority => int.MaxValue;

        private readonly int _pokemonIndex;
        private readonly TeamController _userTeamController;
        
        public SwapPokemonAction(Side side, int pokemonInFieldSpeed, int pokemonIndex, TeamController userTeamController)
            : base(side, pokemonInFieldSpeed)
        {
            _pokemonIndex = pokemonIndex;
            _userTeamController = userTeamController;
        }

        public override async Task Execute(Battle battle)
        {
            await _userTeamController.SwapPokemon(_pokemonIndex);
        }
    }
}