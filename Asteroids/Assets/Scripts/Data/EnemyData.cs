using System;
using DataContainers;

namespace Data
{
    [Serializable]
    public class EnemyData
    {
        public float Speed;
        public int ScorePoint;
        public UniVector2 StartPosition;
    }
}