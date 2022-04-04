using Logic.Player;

namespace Logic.Enemy
{
    public class EnemyModel
    {
        public Transform2D Transform { get; }

        private PlayerModel _playerModel;
        private readonly float _speed;
        
        public EnemyModel(float speed, UniVector2 startPosition, PlayerModel playerModel)
        {
            _playerModel = playerModel;
            _speed = speed;
            Transform = new Transform2D() {Position = startPosition};
        }

        public void Move(float deltaTime)
        {
            Transform.Direction = (_playerModel.Transform.Position - Transform.Position).Normalize();
            var newPosition = Transform.Position + Transform.Direction * _speed * deltaTime;
            Transform.Position = newPosition;
            Transform.OnPositionChanged?.Invoke();
        }
    }
}