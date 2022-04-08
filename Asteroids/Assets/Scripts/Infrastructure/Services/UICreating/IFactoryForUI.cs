using Components;
using UnityEngine;

namespace Infrastructure.Services.UICreating
{
    public interface IFactoryForUI
    {
        Camera CreateCamera();
        CanvasComponents CreateMainCanvas(Camera camera);
        void CreateEventSystem();
        CanvasComponents CreateUIGameSetup();
    }
}