using Pokemon_Battle_Clone.Runtime.Stats.Domain;

namespace Pokemon_Battle_Clone.Runtime.Battles.Domain.Events
{
    public class StatsModifierEvent : IBattleEvent
    {
        public Side ActionSide { get; }
        public StatsModifier Modifier { get; }
        public bool ApplyToTarget { get; }
        public string UserName { get; }
        public string TargetName { get; }
        
        public StatsModifierEvent(Side side, StatsModifier modifier, bool applyToTarget, string userName, string targetName)
        {
            ActionSide = side;
            Modifier = modifier;
            UserName = userName;
            TargetName = targetName;
        }
    }
}