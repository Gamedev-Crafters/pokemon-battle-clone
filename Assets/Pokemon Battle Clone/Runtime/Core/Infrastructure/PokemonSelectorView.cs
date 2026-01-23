using System;
using System.Collections.Generic;
using Pokemon_Battle_Clone.Runtime.Core.Domain;
using UnityEngine;

namespace Pokemon_Battle_Clone.Runtime.Core.Infrastructure
{
    public class PokemonSelectorView : MonoBehaviour
    {
        [SerializeField] private List<PokemonSelectorButton> pokemonButtons;

        public event Action<int> OnPokemonSelected = delegate { };

        public void Init()
        {
            for (int i = 0; i < pokemonButtons.Count; i++)
            {
                pokemonButtons[i].index = i + 1;
                pokemonButtons[i].OnClick += index => OnPokemonSelected(index);
            }
        }

        public void SetData(Team team)
        {
            for (int i = 0; i < pokemonButtons.Count; i++)
            {
                var pokemonIndex = pokemonButtons[i].index;
                if (team.PokemonList.Count > pokemonIndex)
                {
                    pokemonButtons[i].gameObject.SetActive(true);
                    pokemonButtons[i].SetData(team.PokemonList[pokemonIndex].Name);
                }
                else
                {
                    pokemonButtons[i].gameObject.SetActive(false);
                }
            }
        }
    }
}