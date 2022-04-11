using UnityEngine;

namespace ModelLogic.Data.Configs
{
    [CreateAssetMenu(fileName = "BulletData", menuName = "Object Data/Bullet Data")]
    public class BulletData : ScriptableObject
    {
        public float Speed;
        public UniVector2 StartPosition;
        public UniVector2 StartDirection;
    }
}