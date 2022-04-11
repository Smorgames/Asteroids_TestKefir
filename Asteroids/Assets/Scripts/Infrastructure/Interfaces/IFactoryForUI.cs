using Data.Components;
using UnityEngine;

namespace Infrastructure.Interfaces
{
    public interface IFactoryForUI
    {
        Camera CreateCamera();
        CanvasComponents CreateMainCanvas(Camera camera);
        void CreateEventSystem();
        CanvasComponents CreateUIGameSetup();
    }
}