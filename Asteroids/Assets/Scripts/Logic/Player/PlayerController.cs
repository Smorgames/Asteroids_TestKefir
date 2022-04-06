using DataStructers;
using View;

namespace Logic.Player
{
    public class PlayerController
    {
        public PlayerModel Model => _playerModel;

        private readonly PlayerModel _playerModel;
        private readonly PlayerView _playerView;

        public PlayerController(PlayerModel playerModel, PlayerView playerView)
        {
            _playerModel = playerModel;
            _playerView = playerView;
            
            SubscribeOnEvents();
        }

        private void SubscribeOnEvents()
        {
            _playerView.OnAccelerateRequest += ViewAccelerateRequest;
            _playerView.OnSlowdownRequest += ViewSlowdownRequest;
            _playerView.OnRotateRequest += ViewRotateRequest;
            _playerView.OnBulletFireRequest += ViewBulletFireRequest;
            _playerView.OnLaserFireRequest += ViewLaserFireRequest;
            _playerView.OnDeltaTimeUpdate += ViewDeltaTimeUpdate;
            
            _playerModel.Transform.OnPositionChanged += ModelPositionChanged;
            _playerModel.Transform.OnRotationChanged += ModelRotationChanged;
        }

        private void ViewAccelerateRequest() => _playerModel.Accelerate();

        private void ViewSlowdownRequest() => _playerModel.Slowdown();

        private void ViewRotateRequest(float horizontalAxis, UniVector2 moveDirection)
        {
            _playerModel.Rotate(horizontalAxis);
            _playerModel.Transform.Direction = moveDirection;
        }
        
        private void ViewBulletFireRequest() => _playerModel.FireBulletGun();
        
        private void ViewLaserFireRequest(UniVector2 laserSpawnPosition) => 
            _playerModel.FireLaserGun(laserSpawnPosition);
        
        private void ViewDeltaTimeUpdate(float deltaTime)
        {
            _playerModel.DeltaTime = deltaTime;
            _playerModel.OnUpdate?.Invoke();
        }

        private void ModelPositionChanged() => 
            _playerView.SetPosition(_playerModel.Transform.Position);
        
        private void ModelRotationChanged() => 
            _playerView.SetRotation(_playerModel.Transform.Rotation);
    }
}