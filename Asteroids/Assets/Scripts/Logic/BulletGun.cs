using Logic.Player;
using Logic.Pools;

namespace Logic
{
    public class BulletGun
    {
        private readonly PlayerModel _playerModel;
        private readonly BulletPool _bulletPool;
        
        public BulletGun(PlayerModel playerModel, BulletPool bulletPool)
        {
            _playerModel = playerModel;
            _bulletPool = bulletPool;
        }

        public void Fire() => 
            _bulletPool.Instantiate(_playerModel.Transform.Position, _playerModel.Transform.Direction.Copy());
    }
}