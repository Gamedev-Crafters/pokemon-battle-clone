using Pokemon_Battle_Clone.Runtime.Core.Domain;
using Pokemon_Battle_Clone.Runtime.Moves.Domain;
using Pokemon_Battle_Clone.Runtime.Moves.Infrastructure;
using UnityEngine;

namespace Pokemon_Battle_Clone.Runtime.Core.Infrastructure
{
    public class ActionsHUD : MonoBehaviour
    {
        public GameObject selector;
        public PokemonSelectorView pokemonSelector;
        public MoveSetView moveSetView;

        private void Awake()
        {
            HideActions();
            
            moveSetView.Init();
            pokemonSelector.Init();
        }

        public void HideActions()
        {
            selector.SetActive(true);
            moveSetView.gameObject.SetActive(false);
            pokemonSelector.gameObject.SetActive(false);
        }

        public void SetData(Team team, MoveSet moveSet)
        {
            pokemonSelector.SetData(team);
            moveSetView.SetData(moveSet);
        }
    }
}