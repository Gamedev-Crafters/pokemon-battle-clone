using Pokemon_Battle_Clone.Runtime.Core.Domain;
using Pokemon_Battle_Clone.Runtime.Trainer.Domain.Actions;

namespace Pokemon_Battle_Clone.Runtime.Trainer.Domain.Strategies
{
    public class BasicTrainerStrategy : ITrainerStrategy
    {
        public MoveAction SelectMove(Team team)
        {
            var pokemon = team.FirstPokemon;
            var move = pokemon.MoveSet.Moves[0];

            return new MoveAction(Side.Rival, pokemon.Stats.Speed, move);
        }

        public SwapPokemonAction SelectPokemon(Team team)
        {
            var pokemonIndex = FindFirstPokemonAliveIndex(team);
            
            return new SwapPokemonAction(Side.Rival, pokemonIndex);
        }

        private int FindFirstPokemonAliveIndex(Team team)
        {
            var pokemonList = team.PokemonList;
            for (int i = 1; i < pokemonList.Count; i++)
                if (!pokemonList[i].Defeated) return i;
            
            return 0;
        }
    }
}