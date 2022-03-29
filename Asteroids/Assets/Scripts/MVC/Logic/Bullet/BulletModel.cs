using System;

namespace MVC.Logic.Bullet
{
    public class BulletModel
    {
        public Action OnPositionChanged;
        
        private readonly float _speed;
        private readonly UniVector2 _direction;

        private UniVector2 _position;

        public UniVector2 Position
        {
            get => _position;
            set
            {
                if (Equals(value, _position))
                    return;

                _position = value;
                OnPositionChanged?.Invoke();
            }
        }

        public BulletModel(float speed, UniVector2 startPosition, UniVector2 moveDirection)
        {
            _speed = speed;
            _direction = moveDirection.Normalize();
            Position = startPosition;
        }

        public void Move(float physicDeltaTime)
        {
            var newPosition = _position + _direction * _speed * physicDeltaTime;
            Position = newPosition;
        }
    }
}
