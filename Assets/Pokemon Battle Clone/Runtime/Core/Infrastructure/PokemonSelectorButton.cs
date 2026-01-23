using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Pokemon_Battle_Clone.Runtime.Core.Infrastructure
{
    [RequireComponent(typeof(Button))]
    public class PokemonSelectorButton : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI pokemonNameText;
        
         public int index;
        
        public event Action<int> OnClick = delegate { };

        private void Awake()
        {
            GetComponent<Button>().onClick.AddListener(() => OnClick.Invoke(index));
        }

        public void SetData(string pokemonName)
        {
            pokemonNameText.text = pokemonName;
        }
    }
}