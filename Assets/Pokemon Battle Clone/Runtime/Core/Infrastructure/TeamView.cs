using System;
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
        public HealthView healthView;
        public ActionsHUD actionsHUD;

        private Pokemon _pokemonInField;

        private void OnDestroy()
        {
            if (_pokemonInField != null)
                _pokemonInField.Health.OnChanged -= OnHealthChanged;
        }

        public async Task SetPokemon(Pokemon pokemon, Sprite sprite, bool animated)
        {
            if (_pokemonInField != null)
                _pokemonInField.Health.OnChanged -= OnHealthChanged;
            if (animated && _pokemonInField != null)
                await pokemonView.PlayFaintAnimation(); // change to return to pokeball animation
            
            _pokemonInField = pokemon;
            _pokemonInField.Health.OnChanged += OnHealthChanged;
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
        
        private void OnHealthChanged(Health health) => healthView.SetHealth(health.Max, health.Current);
    }
}