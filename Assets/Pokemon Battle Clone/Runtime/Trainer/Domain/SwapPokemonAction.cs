using Pokemon_Battle_Clone.Runtime.Core.Domain;

namespace Pokemon_Battle_Clone.Runtime.Trainer.Domain
{
    public class SwapPokemonAction : TrainerAction
    {
        public override int Priority => int.MaxValue;

        private readonly int _pokemonIndex;
        
        public SwapPokemonAction(Side side, int pokemonInFieldSpeed, int pokemonIndex)
            : base(side, pokemonInFieldSpeed)
        {
            _pokemonIndex = pokemonIndex;
        }

        public override TrainerActionResult Execute(Battle battle)
        {
            var team = battle.GetTeam(Side);
            team.SwapPokemon(0, _pokemonIndex);

            return new SwapActionResult();
        }
    }
}