using DataContainers;
using Logic.Controllers;

namespace Logic.Pools.EnemyPoolDirectory
{
    public interface IEnemyPool
    {
        void Instantiate(UniVector2 startPosition, UniVector2 moveDirection);
        void Destroy(EnemyController enemyController);
    }
}