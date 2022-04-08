using DataContainers;
using Logic.Controllers;

namespace Logic.Pools.LaserPoolDirectory
{
    public interface ILaserPool
    {
        void Instantiate(UniVector2 startPosition, float angle);
        void Destroy(LaserController laserController);
    }
}