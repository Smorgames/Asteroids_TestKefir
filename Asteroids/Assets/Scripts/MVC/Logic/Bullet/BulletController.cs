using MVC.View.Bullet;

namespace MVC.Logic.Bullet
{
    public class BulletController
    {
        private readonly BulletModel _bulletModel;
        private readonly BulletView _bulletView;
        
        public BulletController(BulletModel bulletModel, BulletView bulletView)
        {
            _bulletModel = bulletModel;
            _bulletView = bulletView;
            
            SubscribeOnEvents();
        }

        private void SubscribeOnEvents()
        {
            _bulletView.OnMoveRequest += ViewMoveRequest;
            
            _bulletModel.OnPositionChanged += ModelPositionChanged;
        }

        private void ViewMoveRequest(float physicDeltaTime) => 
            _bulletModel.Move(physicDeltaTime);

        private void ModelPositionChanged() => 
            _bulletView.SetPosition(_bulletModel.Position);
    }
}