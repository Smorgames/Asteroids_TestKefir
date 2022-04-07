using Data;
using DataContainers;
using Logic.Player;

namespace Logic.Enemy
{
    public class EnemyModel : IScore
    {
        public Transform2D Transform { get; }

        private readonly PlayerModel _playerModel;
        private readonly float _speed;
        private readonly int _scorePoint;
        
        public EnemyModel(EnemyData data, PlayerModel playerModel)
        {
            _playerModel = playerModel;
            _speed = data.Speed;
            _scorePoint = data.ScorePoint;
            Transform = new Transform2D {Position = data.StartPosition};
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