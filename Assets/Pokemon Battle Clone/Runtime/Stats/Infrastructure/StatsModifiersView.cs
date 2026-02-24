using System.Collections.Generic;
using Pokemon_Battle_Clone.Runtime.Stats.Domain;
using UnityEngine;

namespace Pokemon_Battle_Clone.Runtime.Stats.Infrastructure
{
    public class StatsModifiersView : MonoBehaviour
    {
        [SerializeField] private StatModifierTag statModifierTagPrefab;
        
        private Dictionary<string, StatModifierTag> statModifierTags = new Dictionary<string, StatModifierTag>();

        struct ModifierDTO
        {
            public string name;
            public float value;
        }
        
        public void Set(StatsModifier modifiers)
        {
            foreach (var modifier in GetModifiers(modifiers))
            {
                if (!statModifierTags.TryGetValue(modifier.name, out StatModifierTag modifierTag))
                {
                    modifierTag = Instantiate(statModifierTagPrefab, transform);
                    statModifierTags.Add(modifier.name, modifierTag);
                }
                modifierTag.SetInfo(modifier.name, modifier.value);
            }
        }

        private List<ModifierDTO> GetModifiers(StatsModifier modifier)
        {
            var modifiers = new List<ModifierDTO>();
            
            if (modifier.AttackBoost != 1f)
                modifiers.Add(new ModifierDTO { name = "Atk.", value = modifier.AttackBoost});
            if (modifier.DefenseBoost != 1f)
                modifiers.Add(new ModifierDTO { name = "Def.", value = modifier.DefenseBoost});
            if (modifier.SpcAttackBoost != 1f)
                modifiers.Add(new ModifierDTO { name = "S.Atk", value = modifier.SpcAttackBoost});
            if (modifier.SpcDefenseBoost != 1f)
                modifiers.Add(new ModifierDTO { name = "S.Def", value = modifier.SpcDefenseBoost});
            if (modifier.SpeedBoost != 1f)
                modifiers.Add(new ModifierDTO { name = "Speed", value = modifier.SpeedBoost});
            
            return modifiers;
        }
    }
}