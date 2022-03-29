using MVC.Logic.Player;
using Services;

namespace MVC.Logic
{
    public class BulletGun
    {
        private readonly PlayerModel _playerModel;
        
        public BulletGun(PlayerModel playerModel) => 
            _playerModel = playerModel;

        public void Fire(UniVector2 direction) => 
            GameFactory.CreateBullet(_playerModel.Position, direction);
    }
}