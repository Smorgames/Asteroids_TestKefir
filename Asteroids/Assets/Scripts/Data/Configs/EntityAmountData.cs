using UnityEngine;

namespace Data.Configs
{
    [CreateAssetMenu(fileName = "EntityAmountData", menuName = "Object Data/Entity Amount Data")]
    public class EntityAmountData : ScriptableObject
    {
        public int EnemyAmount;
        public int NormalMeteorAmount;
        public int SmallMeteorAmount;
        public int BulletAmount;
    }
}