using System.Threading.Tasks;
using Pokemon_Battle_Clone.Runtime.Core.Domain;
using TMPro;
using UnityEngine;

namespace Pokemon_Battle_Clone.Runtime.Core.Infrastructure
{
    public class TeamView : MonoBehaviour, ITeamView
    {
        // just for debugging
        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private TextMeshProUGUI levelText;
        
        [SerializeField] private PokemonView pokemonView;
        public HealthView healthView;
        public ActionsHUD actionsHUD;

        private Pokemon _pokemonInField;

        private void OnDestroy()
        {
            // if (_pokemonInField != null)
            //     _pokemonInField.Health.OnChanged -= OnHealthChanged;
        }
        
        public async Task SendPokemon(Pokemon pokemon, Sprite sprite)
        {
            // if (_pokemonInField != null)
            //     _pokemonInField.Health.OnChanged -= OnHealthChanged;
            if (_pokemonInField != null && !_pokemonInField.Defeated)
                await PlayFaintAnimation(); // change to return to pokeball animation
            
            _pokemonInField = pokemon;
            // _pokemonInField.Health.OnChanged += OnHealthChanged;
            SetStaticData(sprite, pokemon.Name, pokemon.Stats.Level);

            await PlayHitAnimation(); // change to send to field animation
        }

        public void UpdateHealth() => healthView.SetHealth(_pokemonInField.Health.Max, _pokemonInField.Health.Current);

        public Task PlayAttackAnimation() => pokemonView.PlayAttackAnimation();

        public Task PlayHitAnimation() => pokemonView.PlayHitAnimation();

        public Task PlayFaintAnimation() => pokemonView.PlayFaintAnimation();

        private void SetStaticData(Sprite sprite, string name, int level)
        {
            pokemonView.SetSprite(sprite);
            nameText.text = name;
            levelText.text = $"Lvl {level}";
        }
    }
}