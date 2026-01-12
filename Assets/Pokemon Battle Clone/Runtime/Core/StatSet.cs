using System;
using NUnit.Framework;

namespace Pokemon_Battle_Clone.Runtime.Core
{
    public class StatSet
    {
        public int HP { get; private set; }
        public int Attack { get; private set; }
        public int SpcAttack { get; private set; }
        public int Defense { get; private set; }
        public int SpcDefense { get; private set; }
        public int Speed { get; private set; }

        public int Sum => HP + Attack + SpcAttack + Defense + SpcDefense + Speed;
        
        private int _maxStatValue;
        private int _minStatValue;

        public StatSet()
        {
            HP = 0;
            Attack = 0;
            SpcAttack = 0;
            Defense = 0;
            SpcDefense = 0;
            Speed = 0;
            
            _maxStatValue = int.MaxValue;
            _minStatValue = int.MinValue;
        }

        public StatSet(int hp, int attack, int spcAttack, int defense, int spcDefense, int speed)
        {
            HP = hp;
            Attack = attack;
            SpcAttack = spcAttack;
            Defense = defense;
            SpcDefense = spcDefense;
            Speed = speed;
            
            _maxStatValue = int.MaxValue;
            _minStatValue = int.MinValue;
        }

        public static StatSet BlankEVsSet()
        {
            var statSet = new StatSet();
            statSet.SetMinMaxValues(0, 252);

            return statSet;
        }

        public static StatSet BlankIVsSet()
        {
            var statSet = new StatSet();
            statSet.SetMinMaxValues(0, 31);
            
            return statSet;
        }

        /// <summary>
        /// Set min/max stats values and clamps them
        /// </summary>
        public void SetMinMaxValues(int min, int max)
        {
            Assert.IsTrue(min <= max);
            
            _maxStatValue = max;
            _minStatValue = min;
            
            ClampStats();
        }
        
        private void ClampStats()
        {
            HP = Math.Clamp(HP, _minStatValue, _maxStatValue);
            Attack = Math.Clamp(Attack, _minStatValue, _maxStatValue);
            SpcAttack = Math.Clamp(SpcAttack, _minStatValue, _maxStatValue);
            Defense = Math.Clamp(Defense, _minStatValue, _maxStatValue);
            SpcDefense = Math.Clamp(SpcDefense, _minStatValue, _maxStatValue);
            Speed = Math.Clamp(Speed, _minStatValue, _maxStatValue);
        }
    }
}