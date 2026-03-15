using Pokemon_Battle_Clone.Runtime.Core.Domain;
using Pokemon_Battle_Clone.Runtime.Moves.Infrastructure;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Pokemon_Battle_Clone.Runtime.TeamBuilder.UI
{
    public class PokemonCard : MonoBehaviour
    {
        [SerializeField] private Image pokemonIcon;
        [SerializeField] private TextMeshProUGUI pokemonName;
        [SerializeField] private TextMeshProUGUI pokemonLevel;
        [SerializeField] private PokemonCardStats stats;
        [SerializeField] private MoveSetCard moveSet;
        
        public void SetInfo(Pokemon pokemon, Sprite icon)
        {
            pokemonIcon.sprite = icon;
            pokemonName.text = pokemon.Name;
            pokemonLevel.text = $"Lv. {pokemon.Stats.Level}";
            stats.Display(pokemon.Stats.Stats);
            moveSet.Display(MoveSetDTO.Get(pokemon.MoveSet));
        }
    }
}