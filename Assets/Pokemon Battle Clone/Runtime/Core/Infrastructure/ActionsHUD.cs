using Pokemon_Battle_Clone.Runtime.Moves.Infrastructure;
using UnityEngine;

namespace Pokemon_Battle_Clone.Runtime.Core.Infrastructure
{
    public class ActionsHUD : MonoBehaviour
    {
        public GameObject selector;
        public MoveSetView moveSetView;
        public PokemonSelectorView pokemonSelectorView;

        private void Awake()
        {
            selector.SetActive(true);
            moveSetView.gameObject.SetActive(false);
            pokemonSelectorView.gameObject.SetActive(false);
            
            moveSetView.Init();
            pokemonSelectorView.Init();
        }
    }
}