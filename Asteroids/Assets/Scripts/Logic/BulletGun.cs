using Logic.Player;
using Services;

namespace Logic
{
    public class BulletGun
    {
        private readonly PlayerModel _playerModel;
        
        public BulletGun(PlayerModel playerModel) => 
            _playerModel = playerModel;

        public void Fire() => 
            GameFactory.CreateBullet(_playerModel.Transform.Position, _playerModel.Transform.Direction.Copy());
    }
}