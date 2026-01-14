using UnityEngine;
using UnityEngine.UI;

namespace Pokemon_Battle_Clone.Runtime.Core.Infrastructure
{
    public class HealthView : MonoBehaviour
    {
        [SerializeField] private Image fillImage;

        public void UpdateBar(int maxHealth, int currentHealth)
        {
            fillImage.fillAmount = (float)currentHealth / maxHealth;
        }
    }
}