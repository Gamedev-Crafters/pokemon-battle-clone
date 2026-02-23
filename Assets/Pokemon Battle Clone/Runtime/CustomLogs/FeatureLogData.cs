using System.Collections.Generic;
using UnityEngine;

namespace Pokemon_Battle_Clone.Runtime.CustomLogs
{
    [CreateAssetMenu(fileName = "Log Data", menuName = "Custom Logs/Log Data")]
    public class FeatureLogData : ScriptableObject
    {
        [SerializeField] private List<FeatureLog> _features;

        public FeatureLog GetFeatureLog(FeatureType feature)
        {
            return _features?.Find(f => f.feature == feature);
        }
    }
}