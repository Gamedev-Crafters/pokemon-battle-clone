using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Pokemon_Battle_Clone.Runtime.Core.Infrastructure
{
    public class TeamView : MonoBehaviour
    {
        // just for debuging
        [SerializeField] private Image pokemonImage;
        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private TextMeshProUGUI levelText;
        [SerializeField] private HealthView healthView;
        
        public void SetStaticData(Sprite sprite, string name, int level)
        {
            pokemonImage.sprite = sprite;
            nameText.text = name;
            levelText.text = $"Lvl {level}";
        }

        public void SetHealth(int max, int current)
        {
            healthView.UpdateBar(max, current);
        }
    }
}