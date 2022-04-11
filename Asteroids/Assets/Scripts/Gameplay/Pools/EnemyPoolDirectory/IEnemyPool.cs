using Gameplay.Controllers;
using ModelLogic.Data;

namespace Gameplay.Pools.EnemyPoolDirectory
{
    public interface IEnemyPool
    {
        void Instantiate(UniVector2 startPosition, UniVector2 moveDirection);
        void Destroy(EnemyController enemyController);
    }
}