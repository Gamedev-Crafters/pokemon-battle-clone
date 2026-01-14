namespace Pokemon_Battle_Clone.Runtime.Core.Domain
{
    public struct Nature
    {
        public float HP { get; set; }
        public float Attack { get; private set; }
        public float Defense { get; private set; }
        public float SpcAttack { get; private set; }
        public float SpcDefense { get; private set; }
        public float Speed { get; private set; }

        private Nature(float hp, float attack, float spcAttack, float defense, float spcDefense, float speed)
        {
            HP = hp;
            Attack = attack;
            SpcAttack = spcAttack;
            Defense = defense;
            SpcDefense = spcDefense;
            Speed = speed;
        }
        
        /// <summary>
        /// Neutral
        /// </summary>
        public static Nature Hardy() => new Nature(hp: 1f, attack: 1f, spcAttack: 1f, defense: 1f, spcDefense: 1f, speed: 1f);
        /// <summary>
        /// Increased stat: Attack<br/>
        /// Decreased stat: Defense
        /// </summary>
        public static Nature Lonely() => new Nature(hp: 1f, attack: 1.1f, spcAttack: 1f, defense: 0.9f, spcDefense: 1f, speed: 1f);
        /// <summary>
        /// Increased stat: Attack<br/>
        /// Decreased stat: Speed
        /// </summary>
        public static Nature Brave() => new Nature(hp: 1f, attack: 1.1f, spcAttack: 1f, defense: 1f, spcDefense: 1f, speed: 0.9f);
        /// <summary>
        /// Increased stat: Attack<br/>
        /// Decreased stat: Sp. Attack
        /// </summary>
        public static Nature Adamant() => new Nature(hp: 1f, attack: 1.1f, spcAttack: 0.9f, defense: 1f, spcDefense: 1f, speed: 1f);
        /// <summary>
        /// Increased stat: Attack<br/>
        /// Decreased stat: Sp. Defense
        /// </summary>
        public static Nature Naughty() => new Nature(hp: 1f, attack: 1.1f, spcAttack: 1f, defense: 1f, spcDefense: 0.9f, speed: 1f);
        /// <summary>
        /// Increased stat: Defense<br/>
        /// Decreased stat: Attack
        /// </summary>
        public static Nature Bold() => new Nature(hp: 1f, attack: 0.9f, spcAttack: 1f, defense: 1.1f, spcDefense: 1f, speed: 1f);
        /// <summary>
        /// Neutral
        /// </summary>
        public static Nature Docile() => new Nature(hp: 1f, attack: 1f, spcAttack: 1f, defense: 1f, spcDefense: 1f, speed: 1f);
        /// <summary>
        /// Increased stat: Defense<br/>
        /// Decreased stat: Speed
        /// </summary>
        public static Nature Relaxed() => new Nature(hp: 1f, attack: 1f, spcAttack: 1f, defense: 1.1f, spcDefense: 1f, speed: 0.9f);
        /// <summary>
        /// Increased stat: Defense<br/>
        /// Decreased stat: Sp. Attack
        /// </summary>
        public static Nature Impish() => new Nature(hp: 1f, attack: 1f, spcAttack: 0.9f, defense: 1.1f, spcDefense: 1f, speed: 1f);
        /// <summary>
        /// Increased stat: Defense<br/>
        /// Decreased stat: Sp. Defense
        /// </summary>
        public static Nature Lax() => new Nature(hp: 1f, attack: 1f, spcAttack: 1f, defense: 1.1f, spcDefense: 0.9f, speed: 1f);
        /// <summary>
        /// Increased stat: Speed<br/>
        /// Decreased stat: Attack
        /// </summary>
        public static Nature Timid() => new Nature(hp: 1f, attack: 0.9f, spcAttack: 1f, defense: 1f, spcDefense: 1f, speed: 1.1f);
        /// <summary>
        /// Increased stat: Speed<br/>
        /// Decreased stat: Defense
        /// </summary>
        public static Nature Hasty() => new Nature(hp: 1f, attack: 1f, spcAttack: 1f, defense: 0.9f, spcDefense: 1f, speed: 1.1f);
        /// <summary>
        /// Neutral
        /// </summary>
        public static Nature Serious() => new Nature(hp: 1f, attack: 1f, spcAttack: 1f, defense: 1f, spcDefense: 1f, speed: 1f);
        /// <summary>
        /// Increased stat: Speed<br/>
        /// Decreased stat: Sp. Attack
        /// </summary>
        public static Nature Jolly() => new Nature(hp: 1f, attack: 1f, spcAttack: 0.9f, defense: 1f, spcDefense: 1f, speed: 1.1f);
        /// <summary>
        /// Increased stat: Speed<br/>
        /// Decreased stat: Sp. Defense
        /// </summary>
        public static Nature Naive() => new Nature(hp: 1f, attack: 1f, spcAttack: 1f, defense: 0.9f, spcDefense: 1f, speed: 1.1f);
        /// <summary>
        /// Increased stat: Sp. Attack<br/>
        /// Decreased stat: Attack
        /// </summary>
        public static Nature Modest() => new Nature(hp: 1f, attack: 0.9f, spcAttack: 1.1f, defense: 1f, spcDefense: 1f, speed: 1f);
        /// <summary>
        /// Increased stat: Sp. Attack<br/>
        /// Decreased stat: Defense
        /// </summary>
        public static Nature Mild() => new Nature(hp: 1f, attack: 1f, spcAttack: 1.1f, defense: 0.9f, spcDefense: 1f, speed: 1f);
        /// <summary>
        /// Increased stat: Sp. Attack<br/>
        /// Decreased stat: Speed
        /// </summary>
        public static Nature Quiet() => new Nature(hp: 1f, attack: 1f, spcAttack: 1.1f, defense: 1f, spcDefense: 1f, speed: 0.9f);
        /// <summary>
        /// Neutral
        /// </summary>
        public static Nature Bashful() => new Nature(hp: 1f, attack: 1f, spcAttack: 1f, defense: 1f, spcDefense: 1f, speed: 1f);
        /// <summary>
        /// Increased stat: Sp. Attack<br/>
        /// Decreased stat: Sp. Defense
        /// </summary>
        public static Nature Rash() => new Nature(hp: 1f, attack: 1f, spcAttack: 1.1f, defense: 1f, spcDefense: 0.9f, speed: 1f);
        /// <summary>
        /// Increased stat: Sp. Defense<br/>
        /// Decreased stat: Attack
        /// </summary>
        public static Nature Calm() => new Nature(hp: 1f, attack: 0.9f, spcAttack: 1f, defense: 1f, spcDefense: 1.1f, speed: 1f);
        /// <summary>
        /// Increased stat: Sp. Defense<br/>
        /// Decreased stat: Defense
        /// </summary>
        public static Nature Gentle() => new Nature(hp: 1f, attack: 1f, spcAttack: 1f, defense: 0.9f, spcDefense: 1.1f, speed: 1f);
        /// <summary>
        /// Increased stat: Sp. Defense<br/>
        /// Decreased stat: Speed
        /// </summary>
        public static Nature Sassy() => new Nature(hp: 1f, attack: 1f, spcAttack: 1f, defense: 1f, spcDefense: 1.1f, speed: 0.9f);
        /// <summary>
        /// Increased stat: Sp. Defense<br/>
        /// Decreased stat: Sp. Attack
        /// </summary>
        public static Nature Careful() => new Nature(hp: 1f, attack: 1f, spcAttack: 0.9f, defense: 1f, spcDefense: 1.1f, speed: 1f);
        /// <summary>
        /// Neutral
        /// </summary>
        public static Nature Quirky() => new Nature(hp: 1f, attack: 1f, spcAttack: 1f, defense: 1f, spcDefense: 1f, speed: 1f);
    }
}