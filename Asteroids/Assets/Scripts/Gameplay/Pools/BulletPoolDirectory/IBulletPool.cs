using Gameplay.Controllers;
using ModelLogic.Data;

namespace Gameplay.Pools.BulletPoolDirectory
{
    public interface IBulletPool
    {
        void Instantiate(UniVector2 startPosition, UniVector2 moveDirection);
        void Destroy(BulletController bulletController);
    }
}