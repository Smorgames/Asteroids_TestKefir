using DataContainers;
using Enums;
using Logic.Controllers;

namespace Logic.Pools.MeteorPoolDirectory
{
    public interface IMeteorPool
    {
        void Instantiate(UniVector2 startPosition, UniVector2 moveDirection, MeteorType type);
        void Destroy(MeteorController meteorController, MeteorType type);
    }
}