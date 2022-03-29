using MVC.View.Player;

namespace MVC.Logic.Player
{
    public class PlayerController
    {
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
            _playerView.OnMoveRequest += ViewMoveRequest;
            _playerView.OnRotateRequest += ViewRotateRequest;
            _playerView.OnBulletFireRequest += ViewBulletFireRequest;
            _playerView.OnDeltaTimeUpdate += ViewDeltaTimeUpdate;
            
            _playerModel.OnPositionChanged += ModelPositionChanged;
            _playerModel.OnRotationChanged += ModelRotationChanged;
        }

        private void ViewDeltaTimeUpdate(float deltaTime) => 
            _playerModel.DeltaTime = deltaTime;

        private void ViewBulletFireRequest() => 
            _playerModel.Fire();

        private void ViewMoveRequest() => 
            _playerModel.Move();

        private void ModelPositionChanged() => 
            _playerView.SetPosition(_playerModel.Position);

        private void ViewRotateRequest(float horizontalAxis, UniVector2 moveDirection)
        {
            _playerModel.Rotate(horizontalAxis);
            _playerModel.Direction = moveDirection;
        }

        private void ModelRotationChanged() => 
            _playerView.SetRotation(_playerModel.Rotation);
    }
}