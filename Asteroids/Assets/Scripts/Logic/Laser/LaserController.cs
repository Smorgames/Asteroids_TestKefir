using Logic.Pools;
using View;

namespace Logic.Laser
{
    public class LaserController
    {
        public LaserModel Model { get; }
        public LaserView View { get; }
        
        private readonly LaserPool _laserPool;

        public LaserController(LaserModel model, LaserView view, LaserPool laserPool)
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