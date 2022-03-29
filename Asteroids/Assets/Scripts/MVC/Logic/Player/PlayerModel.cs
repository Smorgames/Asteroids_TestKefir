using System;

namespace MVC.Logic.Player
{
    public class PlayerModel
    {
        private const float FloatThreshold = 0.001f;
        
        public Action OnPositionChanged;
        public Action OnRotationChanged;
        
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
        public float Rotation
        {
            get => _rotation;
            private set
            {
                if (Math.Abs(_rotation - value) < FloatThreshold)
                    return;

                _rotation = value;

                OnRotationChanged?.Invoke();
            }
        }
        public UniVector2 Direction { set => _direction = value; }
        public float DeltaTime { set => _deltaTime = value; }

        private readonly BulletGun _bulletGun;
        private UniVector2 _position;
        private UniVector2 _direction;
        private float _rotation;
        private float _rotationSpeed = 150f;
        private float _speed = 2f;
        private float _deltaTime;

        public PlayerModel()
        {
            _direction = new UniVector2(0f, 1f);
            _bulletGun = new BulletGun(this);
        }

        public void Move()
        {
            var newPosition = _position + _direction * _speed * _deltaTime;
            Position = newPosition;
        }

        public void Rotate(float horizontalAxis)
        {
            var delta = horizontalAxis * _rotationSpeed * _deltaTime;
            var rotation = Rotation + delta;
            Rotation = rotation;
        }

        public void Fire() => 
            _bulletGun.Fire(_direction.Copy());
    }
}