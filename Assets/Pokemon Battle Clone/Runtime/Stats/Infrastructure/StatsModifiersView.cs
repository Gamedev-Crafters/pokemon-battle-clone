using System.Collections.Generic;
using Pokemon_Battle_Clone.Runtime.Stats.Domain;
using UnityEngine;

namespace Pokemon_Battle_Clone.Runtime.Stats.Infrastructure
{
    public class StatsModifiersView : MonoBehaviour
    {
        [SerializeField] private StatModifierTag statModifierTagPrefab;
        
        private readonly Dictionary<string, StatModifierTag> _statModifierTags = new();

        private struct ModifierDTO
        {
            public string Name;
            public float Value;
        }

        private void Start()
        {
            InitTags();
        }

        public void Set(StatsModifier modifiers)
        {
            foreach (var modifier in GetModifiers(modifiers))
            {
                if (_statModifierTags.TryGetValue(modifier.Name, out StatModifierTag modifierTag))
                    modifierTag.SetInfo(modifier.Name, modifier.Value);
            }
        }

        private void InitTags()
        {
            var statsModifier = new StatsModifier();
            foreach (var modifier in GetModifiers(statsModifier))
            {
                var modifierTag = CreateTag(modifier);
                modifierTag.SetInfo(modifier.Name, modifier.Value);
            }
        }

        private StatModifierTag CreateTag(ModifierDTO dto)
        {
            var modifierTag = Instantiate(statModifierTagPrefab, transform);
            _statModifierTags.Add(dto.Name, modifierTag);
            return modifierTag;
        }

        private List<ModifierDTO> GetModifiers(StatsModifier modifier)
        {
            var modifiers = new List<ModifierDTO>
            {
                new() { Name = "Atk.", Value = modifier.AttackBoost },
                new() { Name = "Def.", Value = modifier.DefenseBoost },
                new() { Name = "S.Atk", Value = modifier.SpcAttackBoost },
                new() { Name = "S.Def", Value = modifier.SpcDefenseBoost },
                new() { Name = "Speed", Value = modifier.SpeedBoost }
            };
            
            return modifiers;
        }
    }
}