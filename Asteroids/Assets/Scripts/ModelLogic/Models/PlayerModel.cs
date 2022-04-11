using System;
using ModelLogic.Data;
using ModelLogic.Data.Configs;
using ModelLogic.Gameplay;

namespace ModelLogic.Models
{
    public class PlayerModel
    {
        private const float LaserRotationOffset = 90f;
        
        public Action OnUpdate;

        public float DeltaTime { get; set; }
        public Transform2D Transform { get; }
        public LaserGunModel LaserGunModel { get; }
        public BulletGunModel BulletGunModel { get; }

        private readonly Teleport _teleport;
        private readonly PlayerData _playerData;
        private UniVector2 _acceleration;

        public PlayerModel(PlayerData data)
        {
            _playerData = data;
            _acceleration = new UniVector2();
            Transform = new Transform2D(data.StartPosition, data.StartDirection);
            BulletGunModel = new BulletGunModel();
            LaserGunModel = new LaserGunModel(data.LaserReload, data.MaxLaserAmount, this);
            _teleport = new Teleport(data.TeleportLimits.X, data.TeleportLimits.Y, Transform);
        }


        public void Accelerate()
        {
            _acceleration += Transform.Direction * (_playerData.AccelerationTime * DeltaTime);
            
            _acceleration = _acceleration.Magnitude >= _playerData.AccelerationLimit
                ? _acceleration.Normalize() * _playerData.AccelerationLimit
                : _acceleration;
            
            Move();
        }

        public void Slowdown()
        {
            _acceleration -= _acceleration * (DeltaTime / _playerData.SlowdownTime);
            _acceleration = _acceleration.Magnitude < 0 ? _acceleration = new UniVector2() : _acceleration;
            
            Move();
        }

        public void Rotate(float horizontalAxis)
        {
            var delta = horizontalAxis * _playerData.RotationSpeed * DeltaTime;
            var rotation = Transform.Rotation + delta;
            Transform.Rotation = rotation;
        }

        public void FireBulletGun() => BulletGunModel.Fire();

        public void FireLaserGun(UniVector2 laserSpawnPosition) => 
            LaserGunModel.Fire(laserSpawnPosition, Transform.Rotation - LaserRotationOffset);

        public UniVector2 GetInstantSpeed() => _acceleration * _playerData.Speed;

        public int GetMaxLaserAmount() => LaserGunModel.MaxLaserAmount;
        
        public int GetCurrentLaserAmount() => LaserGunModel.CurrentLaserAmount;

        private void Move()
        {
            var newPosition = Transform.Position + _acceleration * _playerData.Speed * DeltaTime;
            Transform.Position = newPosition;
            _teleport.TryTeleport();
        }
    }
}