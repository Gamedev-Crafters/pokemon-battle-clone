using System.Linq;
using Pokemon_Battle_Clone.Runtime.Battles.Domain;
using Pokemon_Battle_Clone.Runtime.Trainers.Domain.Actions;

namespace Pokemon_Battle_Clone.Runtime.Trainers.Domain.Strategies
{
    public class RandomTrainerStrategy : ITrainerStrategy
    {
        public TrainerAction Evaluate(Battle battle, Side side)
        {
            return SelectMove(battle, side);
        }

        public MoveAction SelectMove(Battle battle, Side side)
        {
            var pokemon = battle.GetFirstPokemon(side);
            var moveIndex = battle.Random.Range(0, pokemon.MoveSet.Moves.Count);
            var move = pokemon.MoveSet.Moves[moveIndex];
            
            return new MoveAction(Side.Rival, pokemon.Stats.Speed, move);
        }

        public SwapPokemonAction SelectPokemon(Battle battle, Side side)
        {
            var team = battle.GetTeam(side);
            var alivePokemon = team.Bench.Where(pokemon => !pokemon.Defeated).ToList();
            var pokemonIndex = battle.Random.Range(0, alivePokemon.Count);
            
            return new SwapPokemonAction(Side.Rival, pokemonIndex, withdrawFirstPokemon: !team.FirstPokemon.Defeated);
        }
    }
}