using Pokemon_Battle_Clone.Runtime.Core.Domain;

namespace Pokemon_Battle_Clone.Runtime.Battles.Domain.Events
{
    public class RecoverHealthEvent : IBattleEvent
    {
        public string PokemonName { get; }
        public Health PokemonHealth { get; }
        public Side Side { get; }
        
        public RecoverHealthEvent(string pokemonName, Health pokemonHealth, Side side)
        {
            PokemonName = pokemonName;
            PokemonHealth = pokemonHealth;
            Side = side;
        }
    }
}