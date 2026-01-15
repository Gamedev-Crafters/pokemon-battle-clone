using Pokemon_Battle_Clone.Runtime.Moves.Infrastructure;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Pokemon_Battle_Clone.Runtime.Core.Infrastructure
{
    public class TeamView : MonoBehaviour
    {
        // just for debugging
        [SerializeField] private Image pokemonImage;
        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private TextMeshProUGUI levelText;
        public HealthView health;
        public MoveSetView moveSet;
        
        public void SetStaticData(Sprite sprite, string name, int level)
        {
            pokemonImage.sprite = sprite;
            nameText.text = name;
            levelText.text = $"Lvl {level}";
        }
    }
}