using DataStructers;
using Logic.Player;

namespace Logic.Enemy
{
    public class EnemyModel : IScore
    {
        public Transform2D Transform { get; }

        private readonly PlayerModel _playerModel;
        private readonly float _speed;
        private readonly int _scorePoint;
        
        public EnemyModel(float speed, UniVector2 startPosition, PlayerModel playerModel, int scorePoint)
        {
            _playerModel = playerModel;
            _speed = speed;
            _scorePoint = scorePoint;
            Transform = new Transform2D {Position = startPosition};
        }

        public void Move(float deltaTime)
        {
            Transform.Direction = (_playerModel.Transform.Position - Transform.Position).Normalize();
            var newPosition = Transform.Position + Transform.Direction * _speed * deltaTime;
            Transform.Position = newPosition;
            Transform.OnPositionChanged?.Invoke();
        }

        public int GetScorePoint() => _scorePoint;
    }
}