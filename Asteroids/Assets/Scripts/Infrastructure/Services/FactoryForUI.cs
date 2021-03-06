using Data.Components;
using Infrastructure.Interfaces;
using UnityEngine;

namespace Infrastructure.Services
{
    public class FactoryForUI : IFactoryForUI
    {
        private const string MainCanvasPath = "UI/MainCanvas";
        private const string EventSystemPath = "UI/EventSystem";
        private const string CameraPath = "Camera";
        private readonly Vector3 _cameraDefaultPosition = new Vector3(0f, 0f, -10f);

        public CanvasComponents CreateUIGameSetup()
        {
            CreateEventSystem();
            var camera = CreateCamera();
            return CreateMainCanvas(camera);
        }

        public Camera CreateCamera()
        {
            var cameraPref = Resources.Load<GameObject>(CameraPath);
            var camera = Object.Instantiate(cameraPref, _cameraDefaultPosition, Quaternion.identity).GetComponent<Camera>();
            return camera;
        }
        
        public CanvasComponents CreateMainCanvas(Camera camera)
        {
            var canvasPref = Resources.Load<GameObject>(MainCanvasPath);
            var canvas = Object.Instantiate(canvasPref).GetComponent<Canvas>();
            canvas.worldCamera = camera;
            return canvas.GetComponentInChildren<CanvasComponents>();
        }

        public void CreateEventSystem()
        {
            var eventSystemPref = Resources.Load<GameObject>(EventSystemPath);
            Object.Instantiate(eventSystemPref);
        }
    }
}