using System.Collections.Generic;

namespace Pokemon_Battle_Clone.Runtime.Core.Domain
{
    public class Team
    {
        private readonly List<Pokemon> _pokemonList = new List<Pokemon>();
        public IReadOnlyList<Pokemon> PokemonList => _pokemonList;

        public Pokemon FirstPokemon => _pokemonList[0];
        
        public Team(Pokemon pokemon)
        {
            Add(pokemon);
        }

        public Team(List<Pokemon> pokemonList)
        {
            foreach (var pokemon in pokemonList)
                Add(pokemon);
        }
        
        public bool Add(Pokemon pokemon)
        {
            if (_pokemonList.Count >= 6) return false;
            
            _pokemonList.Add(pokemon);
            return true;
        }
    }
}