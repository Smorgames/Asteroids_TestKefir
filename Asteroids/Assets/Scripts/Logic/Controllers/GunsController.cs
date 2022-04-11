using DataContainers;
using Logic.Models;
using Logic.Pools.BulletPoolDirectory;
using Logic.Pools.LaserPoolDirectory;

namespace Logic.Controllers
{
    public class GunsController
    {
        private readonly PlayerModel _playerModel;
        private readonly ILaserPool _laserPool;
        private readonly IBulletPool _bulletPool;

        public GunsController(PlayerModel playerModel, ILaserPool laserPool, IBulletPool bulletPool)
        {
            _playerModel = playerModel;
            _laserPool = laserPool;
            _bulletPool = bulletPool;

            _playerModel.BulletGunModel.OnFire += BulletGunFired;
            _playerModel.LaserGunModel.OnFire += LaserGunFired;
        }

        private void BulletGunFired() => 
            _bulletPool.Instantiate(_playerModel.Transform.Position, _playerModel.Transform.Direction.Copy());

        private void LaserGunFired(UniVector2 spawnPosition, float rotationAngle) => 
            _laserPool.Instantiate(spawnPosition, rotationAngle);
    }
}