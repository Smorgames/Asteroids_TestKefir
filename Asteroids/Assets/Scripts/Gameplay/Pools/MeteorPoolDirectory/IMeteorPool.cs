using Gameplay.Controllers;
using ModelLogic.Data;
using ModelLogic.Data.Enums;

namespace Gameplay.Pools.MeteorPoolDirectory
{
    public interface IMeteorPool
    {
        void Instantiate(UniVector2 startPosition, UniVector2 moveDirection, MeteorType type);
        void Destroy(MeteorController meteorController, MeteorType type);
    }
}