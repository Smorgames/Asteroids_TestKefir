using Logic.Player;
using Logic.Pools;
using Services;
using UnityEngine.SceneManagement;

namespace Logic
{
    public class Game
    {
        private const int EnemyAmount = 3;
        private const int MeteorAmount = 3;
        private const int BulletAmount = 20;

        private readonly GameFactory _gameFactory;
        private readonly Randomizer _randomizer;
        private readonly SceneManager _sceneManager;
        private readonly HazardSpawnerModel _hazardSpawnerModel;
        private readonly PlayerController _playerController;
        private readonly BulletPool _bulletPool;

        public Game()
        {
            _gameFactory = new GameFactory();
            _randomizer = new Randomizer();
            _sceneManager = new SceneManager();
            _bulletPool = new BulletPool(BulletAmount, _gameFactory, this);
            
            _playerController = _gameFactory.CreatePlayer(new UniVector2(), _bulletPool);

            _hazardSpawnerModel = new HazardSpawnerModel(_playerController, this, _gameFactory);

            for (var i = 0; i < EnemyAmount; i++)
                _hazardSpawnerModel.SpawnEnemy();
            
            for (var i = 0; i < MeteorAmount; i++)
                _hazardSpawnerModel.SpawnMeteor();
        }

        public void EnemyDead() => _hazardSpawnerModel.SpawnEnemy();
        
        public void MeteorDead() => _hazardSpawnerModel.SpawnMeteor();
    }
}