using System.Collections.Generic;
using Pokemon_Battle_Clone.Runtime.Battles.Domain;
using Pokemon_Battle_Clone.Runtime.Battles.Domain.Events;

namespace Pokemon_Battle_Clone.Runtime.Trainers.Domain.Actions
{
    public class SendPokemonAction : TrainerAction
    {
        public override int Priority => int.MaxValue;
        
        public SendPokemonAction(Side side) : base(side, pokemonInFieldSpeed: int.MaxValue) { }

        public override IEnumerable<IBattleEvent> Execute(Battle battle)
        {
            var team = battle.GetTeam(Side);
            var events = new List<IBattleEvent>
            {
                new SendPokemonEvent(Side, team.FirstPokemon)
            };

            return events;
        }
    }
}