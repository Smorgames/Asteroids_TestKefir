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
            _playerView.OnRotateRequest += ViewRotateTick;
            _playerModel.OnPositionChanged += ModelPositionChanged;
            _playerModel.OnRotationChanged += ModelRotationChanged;
        }

        private void ViewMoveRequest(UniVector2 direction) => 
            _playerModel.Move(direction);

        private void ModelPositionChanged()
        {
            var position = _playerModel.GetPosition().ToVector2();
            _playerView.SetPosition(position);
        }

        private void ViewRotateTick(float horizontalAxis)
        {
            var delta = horizontalAxis * _playerModel.GetRotationSpeed();
            var rotation = _playerModel.GetRotation() + delta;
            _playerModel.SetRotation(rotation);
        }

        private void ModelRotationChanged() => 
            _playerView.SetRotation(_playerModel.GetRotation());
    }
}