using System.Threading.Tasks;

namespace Pokemon_Battle_Clone.Runtime.Trainer.Domain
{
    public enum Side
    {
        Player, Rival
    }
    
    public abstract class TrainerAction
    {
        public readonly Side Side;
        public readonly int PokemonInFieldSpeed;
        public abstract int Priority { get; }

        protected TrainerAction(Side side, int pokemonInFieldSpeed)
        {
            Side = side;
            PokemonInFieldSpeed = pokemonInFieldSpeed;
        }

        public abstract Task Execute();
    }
}