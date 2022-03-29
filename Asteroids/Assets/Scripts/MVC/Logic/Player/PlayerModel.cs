using System;

namespace MVC.Logic.Player
{
    public class PlayerModel
    {
        private const float FloatThreshold = 0.001f;
        
        public Action OnPositionChanged;
        public Action OnRotationChanged;
        public Action OnUpdate;
        
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
        public UniVector2 Direction { get; set; }

        public float DeltaTime { get; set; }

        private readonly BulletGun _bulletGun;
        private readonly LaserGun _laserGun;
        private UniVector2 _position;
        private float _rotation;
        private float _rotationSpeed = 150f;
        private float _speed = 2f;

        public PlayerModel()
        {
            Direction = new UniVector2(0f, 1f);
            _bulletGun = new BulletGun(this);
            _laserGun = new LaserGun(2f, this);
        }

        public void Move()
        {
            var newPosition = _position + Direction * _speed * DeltaTime;
            Position = newPosition;
        }

        public void Rotate(float horizontalAxis)
        {
            var delta = horizontalAxis * _rotationSpeed * DeltaTime;
            var rotation = Rotation + delta;
            Rotation = rotation;
        }

        public void FireBulletGun() => 
            _bulletGun.Fire();

        public void FireLaserGun(UniVector2 laserSpawnPosition) =>
            _laserGun.Fire(laserSpawnPosition, Rotation - 90f);
    }
}