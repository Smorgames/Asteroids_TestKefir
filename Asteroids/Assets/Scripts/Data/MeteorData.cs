using System;
using DataContainers;
using Enums;

namespace Data
{
    [Serializable]
    public class MeteorData
    {
        public float Speed;
        public int ScorePoint;
        public MeteorType Type;
        public UniVector2 StartPosition;
        public UniVector2 TeleportLimit;
    }
}