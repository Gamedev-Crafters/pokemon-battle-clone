using System;
using UnityEngine;
using UnityEngine.Assertions;

namespace Pokemon_Battle_Clone.Runtime.Core
{
    public class StatsData
    {
        private int _level;
        public int Level
        {
            get => _level;
            set => _level = Math.Clamp(value, 0, 100);
        }
        private StatSet _evs;
        public StatSet EVs
        {
            get => _evs;
            set
            {
                Assert.IsTrue(value.Sum <= 508);
                _evs = value;
            }
        }
        public StatSet IVs { get; set; }
        public StatSet BaseStats { get; }
        public StatSet Stats { get; private set; }

        public StatsData(int level, StatSet baseStats)
        {
            Level = level;
            BaseStats = baseStats;
            EVs = StatSet.BlankEVsSet();
            IVs = StatSet.BlankIVsSet();
        }

        private static StatSet CalculateStats(int level, StatSet baseStats, StatSet evs, StatSet ivs)
        {
            return new StatSet(
                CalculateHPStat(level, baseStats.HP, evs.HP, ivs.HP),
                CalculateStat(level, baseStats.Attack, evs.Attack, ivs.Attack),
                CalculateStat(level, baseStats.SpcAttack, evs.SpcAttack, ivs.SpcAttack),
                CalculateStat(level, baseStats.Defense, evs.Defense, ivs.Defense),
                CalculateStat(level, baseStats.SpcDefense, evs.SpcDefense, ivs.SpcDefense),
                CalculateStat(level, baseStats.Speed, evs.Speed, ivs.Speed));
        }

        private static int CalculateHPStat(int level, int baseHP, int hpEV, int hpIV)
        {
            return Mathf.FloorToInt((2f * baseHP + hpIV + Mathf.FloorToInt(hpEV / 4f)) * level / 100) + level + 10;
        }

        private static int CalculateStat(int level, int baseStat, int ev, int iv)
        {
            var nature = 0f;
            return Mathf.FloorToInt((Mathf.FloorToInt((2f * baseStat + iv + Mathf.FloorToInt(ev /4f)) * level / 100) + 5) * nature);
        }
    }
}