using System;
using System.Collections.Generic;
using System.Linq;

namespace Pokemon_Battle_Clone.Runtime.Core.Domain
{
    public class Team
    {
        private readonly List<Pokemon> _pokemonList = new List<Pokemon>();
        public IReadOnlyList<Pokemon> PokemonList => _pokemonList;

        public Pokemon FirstPokemon => _pokemonList[0];
        public bool Defeated => _pokemonList.All(pokemon => pokemon.Defeated);
        
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

        public void SwapPokemon(int indexPokemonA, int indexPokemonB)
        {
            if (_pokemonList.Count <= 1)
                throw new InvalidOperationException("Not enough pokemon in the team");
            if (indexPokemonA > _pokemonList.Count - 1 || indexPokemonB > _pokemonList.Count - 1)
                throw new InvalidOperationException("Not enough pokemon in the team");

            (_pokemonList[indexPokemonA], _pokemonList[indexPokemonB]) =
                (_pokemonList[indexPokemonB], _pokemonList[indexPokemonA]);
        }

        public override string ToString()
        {
            return string.Join(", ", PokemonList.Select(pokemon => pokemon.Name));
        }
    }
}