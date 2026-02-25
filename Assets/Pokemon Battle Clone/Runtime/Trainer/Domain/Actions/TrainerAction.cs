using System.Collections.Generic;
using System.Linq;
using Pokemon_Battle_Clone.Runtime.Core.Domain;
using Pokemon_Battle_Clone.Runtime.RNG;

namespace Pokemon_Battle_Clone.Runtime.Trainer.Domain.Actions
{
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

        public abstract TrainerActionResult Execute(Battle battle);

        // public static List<TrainerAction> OrderActions(List<TrainerAction> actionsToOrder)
        // {
        //     return actionsToOrder.OrderByDescending(a => a.Priority)
        //         .ThenByDescending(a => a.PokemonInFieldSpeed)
        //         .ThenBy(_ => RandomProvider.Next())
        //         .ToList();
        // }
    }
}