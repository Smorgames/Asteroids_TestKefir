using ModelLogic.Data.Enums;
using UnityEngine;

namespace ModelLogic.Data.Configs
{
    [CreateAssetMenu(fileName = "MeteorData", menuName = "Object Data/Meteor Data")]
    public class MeteorData : ScriptableObject
    {
        public float Speed;
        public int ScorePoint;
        public MeteorType Type;
        public UniVector2 StartPosition;
        public UniVector2 TeleportLimit;
    }
}