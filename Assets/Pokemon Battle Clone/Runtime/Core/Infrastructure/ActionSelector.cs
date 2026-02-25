using System;
using UnityEngine;
using UnityEngine.UI;

namespace Pokemon_Battle_Clone.Runtime.Core.Infrastructure
{
    public class ActionSelector : MonoBehaviour
    {
        [SerializeField] private Button moveButton;
        [SerializeField] private Button pokemonButton;

        public event Action OnMoveButtonPressed = delegate { };
        public event Action OnPokemonButtonPressed = delegate { };
        
        private void Awake()
        {
            moveButton.onClick.AddListener(() => OnMoveButtonPressed.Invoke());
            pokemonButton.onClick.AddListener(() => OnPokemonButtonPressed.Invoke());
        }

        public void Hide() => gameObject.SetActive(false);
        public void Show() => gameObject.SetActive(true);
    }
}