using MVC.Logic.Player;
using Services;

namespace MVC.Logic
{
    public class LaserGun
    {
        private readonly PlayerModel _playerModel;
        private readonly Counter _counter;
        
        private int _maxFireAmount = 1;
        private int _currentFireAmount;
        
        public LaserGun(float reloadTime, PlayerModel playerModel)
        {
            _playerModel = playerModel;
            _currentFireAmount = _maxFireAmount;
            _counter = new Counter(reloadTime);
            _playerModel.OnUpdate += Update;
            _counter.OnReloaded += ReloadCompleted;
        }

        private void ReloadCompleted()
        {
            if (_currentFireAmount >= _maxFireAmount)
                return;
            
            _currentFireAmount++;
            _counter.Reloaded = false;
        }

        private void Update() => 
            _counter.CounterTick(_playerModel.DeltaTime);

        public void Fire(UniVector2 laserSpawnPosition, float rotation)
        {
            if (_currentFireAmount <= 0)
                return;
            
            GameFactory.CreateLaser(laserSpawnPosition, rotation);
            _currentFireAmount--;
            _counter.Reloaded = false;
        }
    }
}