using Logic.Models;
using Logic.Pools.LaserPoolDirectory;
using Logic.View;

namespace Logic.Controllers
{
    public class LaserController
    {
        public LaserModel Model { get; }
        public LaserView View { get; }
        
        private readonly ILaserPool _laserPool;

        public LaserController(LaserModel model, LaserView view, ILaserPool laserPool)
        {
            Model = model;
            View = view;
            _laserPool = laserPool;

            SubscribeOnEvents();
        }

        private void SubscribeOnEvents()
        {
            View.OnDead += ViewDead;
            
            Model.Transform.OnPositionChanged += ModelPositionChanged;
            Model.Transform.OnRotationChanged += ModelRotationChanged;
        }
        
        private void ViewDead() => 
            _laserPool.Destroy(this);

        private void ModelPositionChanged() => 
            View.SetPosition(Model.Transform.Position);
        private void ModelRotationChanged() => 
            View.SetRotation(Model.Transform.Rotation);
    }
}