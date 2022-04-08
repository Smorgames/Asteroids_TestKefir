using Logic.Pools.BulletPoolDirectory;

namespace Logic.Models
{
    public class BulletGunModel
    {
        private readonly PlayerModel _playerModel;
        private readonly IBulletPool _bulletPool;
        
        public BulletGunModel(PlayerModel playerModel, IBulletPool bulletPool)
        {
            _playerModel = playerModel;
            _bulletPool = bulletPool;
        }

        public void Fire() => 
            _bulletPool.Instantiate(_playerModel.Transform.Position, _playerModel.Transform.Direction.Copy());
    }
}