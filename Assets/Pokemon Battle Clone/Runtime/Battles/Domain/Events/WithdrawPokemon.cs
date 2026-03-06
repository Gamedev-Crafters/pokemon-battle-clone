namespace Pokemon_Battle_Clone.Runtime.Battles.Domain.Events
{
    public class WithdrawPokemon : IBattleEvent
    {
        public Side ActionSide { get; }
        public string PokemonName { get; }
        
        public WithdrawPokemon(Side side, string pokemonName)
        {
            ActionSide = side;
            PokemonName = pokemonName;
        }
    }
}