using System;
using Pokemon_Battle_Clone.Runtime.Core.Domain;
using Pokemon_Battle_Clone.Runtime.Moves.Domain;
using Pokemon_Battle_Clone.Runtime.Moves.Infrastructure;
using UnityEngine;

namespace Pokemon_Battle_Clone.Runtime.Core.Infrastructure
{
    public class ActionsHUD : MonoBehaviour, IActionHUD
    {
        public GameObject selector;
        public PokemonSelectorView pokemonSelector;
        public MoveSetView moveSetView;

        private void Awake()
        {
            Hide();
            
            moveSetView.Init();
            pokemonSelector.Init();
        }

        public void Hide()
        {
            selector.SetActive(true);
            moveSetView.Hide();
            pokemonSelector.Hide();
        }

        public void ShowMoveSelector(bool forceSelection)
        {
            selector.SetActive(false);
            moveSetView.Show(forceSelection);
            pokemonSelector.Hide();
        }

        public void ShowPokemonSelector(bool forceSelection)
        {
            selector.SetActive(false);
            moveSetView.Hide();
            pokemonSelector.Show(forceSelection);
        }

        public void SetData(Team team, MoveSet moveSet)
        {
            pokemonSelector.SetData(team);
            moveSetView.SetData(moveSet);
        }

        public void RegisterMoveSelectedListener(Action<int> listener) => moveSetView.OnMoveSelected += listener;
        public void RegisterPokemonSelectedListener(Action<int> listener) => pokemonSelector.OnPokemonSelected += listener;
    }
}