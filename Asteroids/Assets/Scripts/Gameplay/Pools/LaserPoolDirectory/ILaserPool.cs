using Gameplay.Controllers;
using ModelLogic.Data;

namespace Gameplay.Pools.LaserPoolDirectory
{
    public interface ILaserPool
    {
        void Instantiate(UniVector2 startPosition, float angle);
        void Destroy(LaserController laserController);
    }
}