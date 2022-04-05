using Logic.Pools;
using View;

namespace Logic.Bullet
{
    public class BulletController
    {
        public BulletView View { get; }

        public BulletModel Model { get; }

        private readonly BulletPool _bulletPool;

        public BulletController(BulletModel bulletModel, BulletView bulletView, BulletPool bulletPool)
        {
            Model = bulletModel;
            View = bulletView;
            _bulletPool = bulletPool;
            
            SubscribeOnEvents();
        }

        private void SubscribeOnEvents()
        {
            View.OnMoveRequest += ViewMoveRequest;
            View.OnDead += ViewDead;
            Model.Transform.OnPositionChanged += ModelPositionChanged;
        }

        private void ViewMoveRequest(float physicDeltaTime) => 
            Model.Move(physicDeltaTime);

        private void ViewDead() => _bulletPool.Destroy(this);

        private void ModelPositionChanged() => 
            View.SetPosition(Model.Transform.Position);
    }
}