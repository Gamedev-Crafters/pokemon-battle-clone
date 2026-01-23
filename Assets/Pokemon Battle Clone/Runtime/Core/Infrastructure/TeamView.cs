using TMPro;
using UnityEngine;

namespace Pokemon_Battle_Clone.Runtime.Core.Infrastructure
{
    public class TeamView : MonoBehaviour
    {
        // just for debugging
        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private TextMeshProUGUI levelText;
        
        public PokemonView pokemon;
        public HealthView health;
        public ActionsHUD actionsHUD;
        
        public void SetStaticData(Sprite sprite, string name, int level)
        {
            pokemon.SetSprite(sprite);
            nameText.text = name;
            levelText.text = $"Lvl {level}";
        }
    }
}