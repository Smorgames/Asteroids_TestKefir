using System;
using DataContainers;

namespace Data
{
    [Serializable]
    public class PlayerData
    {
        public float Speed;
        public float RotationSpeed;
        public float SlowdownTime;
        public float AccelerationTime;
        public float AccelerationLimit;
        public float LaserReload;
        public int MaxLaserAmount;
        public UniVector2 StartPosition;
        public UniVector2 StartDirection;
        public UniVector2 TeleportLimits;
    }
}