namespace Logic.Meteor
{
    public class MeteorModel
    {
        public Transform2D Transform { get; }

        private readonly float _speed;

        public MeteorModel(float speed, UniVector2 startPosition, UniVector2 moveDirection)
        {
            _speed = speed;
            Transform = new Transform2D(moveDirection.Normalize()) { Position = startPosition };
        }

        public void Move(float deltaTime)
        {
            var newPosition = Transform.Position + Transform.Direction * _speed * deltaTime;
            Transform.Position = newPosition;
            Transform.OnPositionChanged?.Invoke();
        }
    }
}