using UnityEngine;

namespace Pokemon_Battle_Clone.Runtime.CustomLogs
{
    public enum FeatureType
    {
        Undefined, Battle, Action, Player, Rival
    }
    
    [System.Serializable]
    public class FeatureLog
    {
        public FeatureType feature;
        public Color customColor;
        public bool enabled;
    }
}