using System.Linq;
using PokeApiNet;
using UnityEngine;

namespace Pokemon_Battle_Clone.Runtime
{
    public class SearchAPI : MonoBehaviour
    {
        public string pokemonName;

        private PokeApiClient _pokeClient;
        private PokeApiClient Client
        {
            get
            {
                if (_pokeClient == null)
                    _pokeClient = new PokeApiClient();
                return _pokeClient;
            }
        }
        
        [ContextMenu("Search Pokemon")]
        private async void SearchPokemon()
        {
            Pokemon pokemon = await Client.GetResourceAsync<Pokemon>(pokemonName);
            // Debug.Log(string.Join(',', pokemon.Abilities.Select(ability => ability.Ability.Name)));
            Debug.Log($"{pokemon.Name} --> " +
                      $"<a href={pokemon.Sprites.FrontDefault}>front sprite</a> | " +
                      $"<a href={pokemon.Sprites.BackDefault}>back sprite</a> | " +
                      $"<a href={pokemon.Sprites.Versions.GenerationVIII.Icons.FrontDefault}>icon</a>");
        }
    }
}