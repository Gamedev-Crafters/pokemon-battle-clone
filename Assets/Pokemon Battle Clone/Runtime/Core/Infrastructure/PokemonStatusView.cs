using TMPro;
using UnityEngine;

namespace Pokemon_Battle_Clone.Runtime.Core.Infrastructure
{
    public class PokemonStatusView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private TextMeshProUGUI levelText;
        [SerializeField] private HealthView healthView;
        
        public void UpdateHealth(int max, int current, bool animated) => healthView.SetHealth(max, current, animated);

        public void SetInfo(string name, int level)
        {
            nameText.text = name;
            levelText.text = $"Lvl {level}";
        }
    }
}