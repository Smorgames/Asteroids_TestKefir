using ModelLogic.Data;
using ModelLogic.Data.Configs;
using ModelLogic.Interfaces;

namespace ModelLogic.Models
{
    public class EnemyModel : IScore
    {
        public Transform2D Transform { get; }

        private readonly PlayerModel _playerModel;
        private readonly EnemyData _enemyData;

        public EnemyModel(EnemyData data, PlayerModel playerModel)
        {
            _enemyData = data;
            _playerModel = playerModel;
            Transform = new Transform2D {Position = data.StartPosition};
        }

        public void Move(float deltaTime)
        {
            Transform.Direction = (_playerModel.Transform.Position - Transform.Position).Normalize();
            var newPosition = Transform.Position + Transform.Direction * _enemyData.Speed * deltaTime;
            Transform.Position = newPosition;
            Transform.OnPositionChanged?.Invoke();
        }

        public int GetScorePoint() => _enemyData.ScorePoint;
    }
}