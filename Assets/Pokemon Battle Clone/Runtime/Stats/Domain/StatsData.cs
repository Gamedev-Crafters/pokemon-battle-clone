using System;
using Pokemon_Battle_Clone.Runtime.Moves;
using UnityEngine;
using UnityEngine.Assertions;

namespace Pokemon_Battle_Clone.Runtime.Stats.Domain
{
    public class StatsData
    {
        private int _level;
        public int Level
        {
            get => _level;
            set => _level = Math.Clamp(value, 1, 100);
        }
        private StatSet _evs;
        public StatSet EVs
        {
            get => _evs;
            set
            {
                Assert.IsTrue(value.Sum <= 510);
                _evs = value;
                Stats = CalculateStats(Level, BaseStats, EVs, IVs, Nature);
            }
        }

        private StatSet _ivs;
        public StatSet IVs
        {
            get => _ivs;
            set
            {
                _ivs = value;
                Stats = CalculateStats(Level, BaseStats, EVs, IVs, Nature);
            }
        }
        public StatSet BaseStats { get; }
        public StatSet Stats { get; private set; }
        
        public Nature Nature { get; }
        public StatsModifier Modifiers { get; }

        public StatsData(int level, StatSet baseStats, Nature nature)
        {
            Level = level;
            BaseStats = baseStats;
            Nature = nature;
            Modifiers = new StatsModifier();
            
            _evs = StatSet.BlankEVsSet();
            _ivs = StatSet.BlankIVsSet();

            Stats = CalculateStats(Level, BaseStats, EVs, IVs, Nature);
        }

        public int GetAttackByCategory(MoveCategory category)
        {
            return category switch
            {
                MoveCategory.Physical => Mathf.FloorToInt(Stats.Attack * Modifiers.AttackBoost),
                MoveCategory.Special => Mathf.FloorToInt(Stats.SpcAttack * Modifiers.SpcAttackBoost),
                _ => 0
            };
        }
        
        public int GetDefenseByCategory(MoveCategory category)
        {
            return category switch
            {
                MoveCategory.Physical => Mathf.FloorToInt(Stats.Defense * Modifiers.DefenseBoost),
                MoveCategory.Special => Mathf.FloorToInt(Stats.SpcDefense * Modifiers.SpcDefenseBoost),
                _ => 0
            };
        }

        private static StatSet CalculateStats(int level, StatSet baseStats, StatSet evs, StatSet ivs, Nature nature)
        {
            return new StatSet(
                CalculateHPStat(level, baseStats.HP, evs.HP, ivs.HP),
                CalculateStat(level, baseStats.Attack, evs.Attack, ivs.Attack, nature.Attack),
                CalculateStat(level, baseStats.Defense, evs.Defense, ivs.Defense, nature.Defense),
                CalculateStat(level, baseStats.SpcAttack, evs.SpcAttack, ivs.SpcAttack, nature.SpcAttack),
                CalculateStat(level, baseStats.SpcDefense, evs.SpcDefense, ivs.SpcDefense, nature.SpcDefense),
                CalculateStat(level, baseStats.Speed, evs.Speed, ivs.Speed, nature.Speed));
        }

        private static int CalculateHPStat(int level, int baseHP, int hpEV, int hpIV)
        {
            return Mathf.FloorToInt((2f * baseHP + hpIV + Mathf.FloorToInt(hpEV / 4f)) * level / 100) + level + 10;
        }

        private static int CalculateStat(int level, int baseStat, int ev, int iv, float natureModifier)
        {
            return Mathf.FloorToInt(((2 * baseStat + iv + ev / 4) * level / 100 + 5) * natureModifier);
        }
    }
}