using TMPro;
using UnityEngine;

namespace Pokemon_Battle_Clone.Runtime.Stats.Infrastructure
{
    public class StatModifierTag : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI text;

        public void SetInfo(string statName, float value) => text.text = $"{statName} x{value:0.###}";
    }
}