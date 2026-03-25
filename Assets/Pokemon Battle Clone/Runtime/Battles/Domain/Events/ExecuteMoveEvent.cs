namespace Pokemon_Battle_Clone.Runtime.Battles.Domain.Events
{
    public class ExecuteMoveEvent : IBattleEvent
    {
        public Side ActionSide { get; }
        public string PokemonName { get; }
        public string MoveName { get; }

        public ExecuteMoveEvent(Side side, string pokemonName, string moveName)
        {
            ActionSide = side;
            PokemonName = pokemonName;
            MoveName = moveName;
        }
    }
}