using System;
using DataStructers;
using Logic.Guns;
using Logic.Pools;

namespace Logic.Player
{
    public class PlayerModel
    {
        public Action OnUpdate;

        public float DeltaTime { get; set; }
        public Transform2D Transform { get; }
        public LaserGun LaserGun { get; }

        private readonly BulletGun _bulletGun;
        private readonly Teleport _teleport;
        private UniVector2 _acceleration = new UniVector2();
        private float _rotationSpeed = 150f;
        private float _speed = 2f;

        private float _slowdownTime = 1f;
        private float _accelerationTime = 1f;
        private float _accelerationLimit = 1f;

        public PlayerModel(UniVector2 startPosition, BulletPool bulletPool, LaserPool laserPool, int maxLaserAmount)
        {
            Transform = new Transform2D(startPosition, new UniVector2(0f, 1f));
            _bulletGun = new BulletGun(this, bulletPool);
            LaserGun = new LaserGun(2f, this, laserPool, maxLaserAmount);
            _teleport = new Teleport(9.05f, 5.15f, Transform);
        }


        public void Accelerate()
        {
            _acceleration += Transform.Direction * (_accelerationTime * DeltaTime);
            
            _acceleration = _acceleration.Magnitude >= _accelerationLimit
                ? _acceleration.Normalize() * _accelerationLimit
                : _acceleration;
            
            Move();
        }

        public void Slowdown()
        {
            _acceleration -= _acceleration * (DeltaTime / _slowdownTime);
            _acceleration = _acceleration.Magnitude < 0 ? _acceleration = new UniVector2() : _acceleration;
            
            Move();
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
            LaserGun.Fire(laserSpawnPosition, Transform.Rotation - 90f);

        public UniVector2 GetInstantSpeed() => _acceleration * _speed;

        public int GetMaxLaserAmount() => LaserGun.MaxLaserAmount;
        
        public int GetCurrentLaserAmount() => LaserGun.CurrentLaserAmount;

        private void Move()
        {
            var newPosition = Transform.Position + _acceleration * _speed * DeltaTime;
            Transform.Position = newPosition;
            _teleport.TryTeleport();
        }
    }
}