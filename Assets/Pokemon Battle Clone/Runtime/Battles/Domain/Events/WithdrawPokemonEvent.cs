namespace Pokemon_Battle_Clone.Runtime.Battles.Domain.Events
{
    public class WithdrawPokemonEvent : IBattleEvent
    {
        public Side ActionSide { get; }
        public string PokemonName { get; }
        
        public WithdrawPokemonEvent(Side side, string pokemonName)
        {
            ActionSide = side;
            PokemonName = pokemonName;
        }
    }
}