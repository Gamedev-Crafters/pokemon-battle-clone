using System.Threading.Tasks;
using Pokemon_Battle_Clone.Runtime.Core.Domain;
using TMPro;
using UnityEngine;

namespace Pokemon_Battle_Clone.Runtime.Core.Infrastructure
{
    public class TeamView : MonoBehaviour, ITeamView
    {
        [SerializeField] private PokemonStatusView pokemonStatusView;
        [SerializeField] private PokemonView pokemonView;
        
        private Pokemon _pokemonInField;
        
        public async Task SendPokemon(Pokemon pokemon, Sprite sprite)
        {
            if (_pokemonInField != null && !_pokemonInField.Defeated)
                await PlayFaintAnimation(); // change to return to pokeball animation
            
            _pokemonInField = pokemon;
            SetStaticData(sprite, pokemon.Name, pokemon.Stats.Level);
            UpdateHealth(_pokemonInField.Health.Max, _pokemonInField.Health.Current, animated: false);

            await PlayHitAnimation(); // change to send to field animation
        }

        public void UpdateHealth(int max, int current, bool animated) => pokemonStatusView.UpdateHealth(max, current, animated);

        public Task PlayAttackAnimation() => pokemonView.PlayAttackAnimation();

        public Task PlayHitAnimation() => pokemonView.PlayHitAnimation();

        public Task PlayFaintAnimation() => pokemonView.PlayFaintAnimation();

        private void SetStaticData(Sprite sprite, string name, int level)
        {
            pokemonView.SetSprite(sprite);
            pokemonStatusView.SetInfo(name, level);
        }
    }
}