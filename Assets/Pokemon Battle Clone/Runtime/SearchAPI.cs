using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using PokeApiNet;
using UnityEditor;
using UnityEngine;
using UnityEngine.Windows;

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
        private async Task SearchPokemon()
        {
            Pokemon pokemon = await Client.GetResourceAsync<Pokemon>(pokemonName);
            // Debug.Log(string.Join(',', pokemon.Abilities.Select(ability => ability.Ability.Name)));
            Debug.Log($"{pokemon.Name} --> " +
                      $"<a href={pokemon.Sprites.FrontDefault}>front sprite</a> | " +
                      $"<a href={pokemon.Sprites.BackDefault}>back sprite</a> | " +
                      $"<a href={pokemon.Sprites.Versions.GenerationVIII.Icons.FrontDefault}>icon</a>");
            
            var s = pokemon.Stats;
            foreach (var pokemonStat in s)
            {
                Debug.Log($"{pokemonStat.Stat.Name} = {pokemonStat.BaseStat}");
            }

            var t = pokemon.Types;
            var type1 = t[0].Type.Name;
            var type2 = t[1].Type.Name;
            Debug.Log($"Type 1: {type1}");
            Debug.Log($"Type 2: {type2}");
        }

        [ContextMenu("Download Pokemon Sprites")]
        private async Task DownloadSprites()
        {
            const string frontFolder = "C:\\Unity\\Projects\\pokemon-battle-clone\\Assets\\Pokemon Battle Clone\\Sprites\\Pokemon\\Front";
            const string backFolder = "C:\\Unity\\Projects\\pokemon-battle-clone\\Assets\\Pokemon Battle Clone\\Sprites\\Pokemon\\Back";
            const string iconFolder = "C:\\Unity\\Projects\\pokemon-battle-clone\\Assets\\Pokemon Battle Clone\\Sprites\\Pokemon\\Icon";
            
            var pokemon = await Client.GetResourceAsync<Pokemon>(pokemonName);

            await DownloadSprite(pokemon.Sprites.FrontDefault, frontFolder + $"\\{pokemon.Id}.png");
            await DownloadSprite(pokemon.Sprites.BackDefault, backFolder + $"\\{pokemon.Id}.png");
            await DownloadSprite(pokemon.Sprites.Versions.GenerationVIII.Icons.FrontDefault, iconFolder + $"\\{pokemon.Id}.png");
            
            Debug.Log($"{pokemon.Name}'s sprites downloaded!");
            
            AssetDatabase.Refresh();
        }

        private async Task DownloadSprite(string url, string filePath)
        {
            if (string.IsNullOrEmpty(url))
            {
                Debug.Log("url mala tonto!!");
                return;
            }
            
            using (var client = new HttpClient())
            {
                var bytes = await client.GetByteArrayAsync(url);
                File.WriteAllBytes(filePath, bytes);
            }
        }
    }
}