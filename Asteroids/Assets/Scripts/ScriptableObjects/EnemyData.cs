using DataContainers;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "Object Data/Enemy Data")]
    public class EnemyData : ScriptableObject
    {
        public float Speed;
        public int ScorePoint;
        public UniVector2 StartPosition;
    }
}