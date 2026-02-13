using System.Threading.Tasks;
using Pokemon_Battle_Clone.Runtime.Core.Domain;
using TMPro;
using UnityEngine;

namespace Pokemon_Battle_Clone.Runtime.Core.Infrastructure
{
    public class TeamView : MonoBehaviour
    {
        // just for debugging
        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private TextMeshProUGUI levelText;
        
        public PokemonView pokemonView;
        public HealthView health;
        public ActionsHUD actionsHUD;

        private Pokemon _pokemonInField; 
        
        public async Task SetPokemon(Pokemon pokemon, Sprite sprite, bool animated)
        {
            if (animated && _pokemonInField != null)
                await pokemonView.PlayFaintAnimation(); // change to return to pokeball animation
            
            _pokemonInField = pokemon;
            SetStaticData(sprite, pokemon.Name, pokemon.Stats.Level);

            if (animated)
                await pokemonView.PlayHitAnimation(); // change to send to field animation
        }
        
        public void SetStaticData(Sprite sprite, string name, int level)
        {
            pokemonView.SetSprite(sprite);
            nameText.text = name;
            levelText.text = $"Lvl {level}";
        }
    }
}