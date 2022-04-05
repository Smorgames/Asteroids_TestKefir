using Services;

namespace Logic.Meteor
{
    public class MeteorModel
    {
        public Transform2D Transform { get; }

        private readonly GameFactory _gameFactory;
        private readonly float _speed;
        private readonly Teleport _teleport;
        private readonly int _smallMeteorAmount = 3;
        private readonly MeteorType _type;

        public MeteorModel(float speed, UniVector2 startPosition, UniVector2 moveDirection, MeteorType type,
            GameFactory gameFactory)
        {
            _gameFactory = gameFactory;
            _speed = speed;
            _type = type;
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
            if (_type == MeteorType.Small)
                return;
            
            for (var i = 0; i < _smallMeteorAmount; i++)
            {
                var randomDirection = new UniVector2(Randomizer.Random(-1f, 1f), Randomizer.Random(-1f, 1f)).Normalize();
                _gameFactory.CreateSmallMeteor(_speed * 1.5f, Transform.Position, randomDirection);
            }
        }
    }
}