using UnityEngine;

namespace ModelLogic.Data.Configs
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "Object Data/Enemy Data")]
    public class EnemyData : ScriptableObject
    {
        public float Speed;
        public int ScorePoint;
        public UniVector2 StartPosition;
    }
}