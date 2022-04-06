using DataStructers;
using Enums;
using Logic.Pools;
using Services;

namespace Logic.Meteor
{
    public class MeteorModel : IScore
    {
        private const int SmallMeteorAmount = 2;
        
        public Transform2D Transform { get; }
        public MeteorType Type { get; }
        public MeteorPool Pool { get; }

        private readonly float _speed;
        private readonly Teleport _teleport;
        private readonly int _scorePoint;

        public MeteorModel(float speed, UniVector2 startPosition, 
            UniVector2 moveDirection, MeteorType type, MeteorPool meteorPool, int scorePoint)
        {
            Pool = meteorPool;
            _scorePoint = scorePoint;
            _speed = speed;
            Type = type;
            Transform = new Transform2D(moveDirection.Normalize()) { Position = startPosition };
            _teleport = new Teleport(9.05f, 5.15f, Transform);
        }

        public void Move(float deltaTime)
        {
            var newPosition = Transform.Position + Transform.Direction * _speed * deltaTime;
            Transform.Position = newPosition;
            Transform.OnPositionChanged?.Invoke();
            _teleport.TryTeleport();
        }

        public void Dead()
        {
            if (Type == MeteorType.Small)
                return;
            
            for (var i = 0; i < SmallMeteorAmount; i++)
            {
                var randomDirection = new UniVector2(Randomizer.Random(-1f, 1f), Randomizer.Random(-1f, 1f)).Normalize();
                Pool.Instantiate(Transform.Position, randomDirection, MeteorType.Small);
            }
        }

        public int GetScorePoint() => _scorePoint;
    }
}