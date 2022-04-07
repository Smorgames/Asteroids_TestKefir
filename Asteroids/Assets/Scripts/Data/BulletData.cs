using System;
using DataContainers;

namespace Data
{
    [Serializable]
    public class BulletData
    {
        public float Speed;
        public UniVector2 StartPosition;
        public UniVector2 StartDirection;
    }
}