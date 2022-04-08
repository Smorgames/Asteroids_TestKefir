using Logic.Models;
using Logic.Pools.BulletPoolDirectory;
using Logic.View;

namespace Logic.Controllers
{
    public class BulletController
    {
        public BulletView View { get; }

        public BulletModel Model { get; }

        private readonly IBulletPool _bulletPool;

        public BulletController(BulletModel bulletModel, BulletView bulletView, IBulletPool bulletPool)
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