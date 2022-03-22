using MVC.Logic.Player;

namespace MVC.Logic
{
    public class Gun
    {
        private readonly PlayerModel _playerModel;

        private float _reloadTime;

        public Gun(PlayerModel playerModel)
        {
            _playerModel = playerModel;
        }

        public void Shot()
        {
            
        }
    }
}