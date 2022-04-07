using DataContainers;

namespace Logic.Bullet
{
    public class BulletModel
    {
        public Transform2D Transform { get; }

        private readonly float _speed;

        public BulletModel(in float speed, UniVector2 startPosition, UniVector2 moveDirection)
        {
            _speed = speed;
            Transform = new Transform2D { Position = startPosition, Direction = moveDirection.Normalize()};
        }

        public void Move(float physicDeltaTime)
        {
            var newPosition = Transform.Position + Transform.Direction * _speed * physicDeltaTime;
            Transform.Position = newPosition;
            Transform.OnPositionChanged?.Invoke();
        }
    }
}