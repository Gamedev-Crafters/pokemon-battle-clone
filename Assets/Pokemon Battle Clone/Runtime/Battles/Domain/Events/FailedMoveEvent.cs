namespace Pokemon_Battle_Clone.Runtime.Battles.Domain.Events
{
    public class FailedMoveEvent : IBattleEvent
    {
        public string PokemonName { get; }
        public string MoveName { get; }
        
        public FailedMoveEvent(string pokemonName, string moveName)
        {
            PokemonName = pokemonName;
            MoveName = moveName;
        }
    }
}