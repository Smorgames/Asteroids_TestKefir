using System;
using Logic.Pools;
using Services;

namespace Logic.Player
{
    public class PlayerModel
    {
        public Action OnUpdate;

        public float DeltaTime { get; set; }
        public Transform2D Transform { get; }

        private readonly BulletGun _bulletGun;
        private readonly LaserGun _laserGun;
        private readonly Teleport _teleport;
        private float _rotationSpeed = 150f;
        private float _speed = 2f;

        public PlayerModel(UniVector2 startPosition, BulletPool bulletPool, GameFactory gameFactory)
        {
            Transform = new Transform2D(startPosition, new UniVector2(0f, 1f));
            _bulletGun = new BulletGun(this, bulletPool);
            _laserGun = new LaserGun(2f, this, gameFactory);
            _teleport = new Teleport(9.05f, 5.15f, Transform);
        }

        public void Move()
        {
            var newPosition = Transform.Position + Transform.Direction * _speed * DeltaTime;
            Transform.Position = newPosition;
            _teleport.TryTeleport();
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