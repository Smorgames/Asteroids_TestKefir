using Logic.Player;
using Services;

namespace Logic
{
    public class LaserGun
    {
        private readonly PlayerModel _playerModel;
        private readonly Counter _counter;
        private readonly GameFactory _gameFactory;
        
        private int _maxFireAmount = 1;
        private int _currentFireAmount;
        
        public LaserGun(float reloadTime, PlayerModel playerModel, GameFactory gameFactory)
        {
            _playerModel = playerModel;
            _gameFactory = gameFactory;
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
            
            _gameFactory.CreateLaser(laserSpawnPosition, rotation);
            _currentFireAmount--;
            _counter.Reloaded = false;
        }
    }
}