using System;

namespace Logic.Player
{
    public class PlayerModel
    {
        private const float FloatThreshold = 0.001f;
        
        public Action OnUpdate;

        public float DeltaTime { get; set; }
        public Transform2D Transform { get; }

        private readonly BulletGun _bulletGun;
        private readonly LaserGun _laserGun;
        private float _rotationSpeed = 150f;
        private float _speed = 2f;

        public PlayerModel()
        {
            Transform = new Transform2D(new UniVector2(0f, 1f));
            _bulletGun = new BulletGun(this);
            _laserGun = new LaserGun(2f, this);
        }

        public void Move()
        {
            var newPosition = Transform.Position + Transform.Direction * _speed * DeltaTime;
            Transform.Position = newPosition;
        }

        public void Rotate(float horizontalAxis)
        {
            var delta = horizontalAxis * _rotationSpeed * DeltaTime;
            var rotation = Transform.Rotation + delta;
            Transform.Rotation = rotation;
        }

        public void FireBulletGun() => 
            _bulletGun.Fire();

        public void FireLaserGun(UniVector2 laserSpawnPosition) =>
            _laserGun.Fire(laserSpawnPosition, Transform.Rotation - 90f);
    }
}