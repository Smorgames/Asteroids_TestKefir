using DataContainers;
using Logic.Controllers;

namespace Logic.Pools.BulletPoolDirectory
{
    public interface IBulletPool
    {
        void Instantiate(UniVector2 startPosition, UniVector2 moveDirection);
        void Destroy(BulletController bulletController);
    }
}