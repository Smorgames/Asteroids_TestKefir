using DataStructers;
using Enums;
using Logic;
using Logic.Player;
using Logic.Pools;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Services
{
    public class Game
    {
        private const int EnemyAmount = 3;
        private const int MaxLaserAmount = 4;
        private const int NormalMeteorAmount = 2;
        private const int SmallMeteorAmount = 10;
        private const int BulletAmount = 20;
        private const float NormalMeteorSpeed = 3f;
        private const float SmallMeteorSpeed = 4.5f;
        private const float EnemySpeed = 1f;
        private const int SmallMeteorScorePoint = 100;
        private const int NormalMeteorScorePoint = 300;
        private const int EnemyScorePoint = 500;

        private readonly GameFactory _gameFactory;
        private readonly Randomizer _randomizer;
        private readonly SceneManager _sceneManager;
        private readonly HazardSpawner _hazardSpawner;
        private readonly PlayerController _playerController;
        
        private readonly BulletPool _bulletPool;
        private readonly EnemyPool _enemyPool;
        private readonly MeteorPool _meteorPool;
        private readonly LaserPool _laserPool;

        public Game()
        {
            _gameFactory = new GameFactory();
            _bulletPool = new BulletPool(BulletAmount, _gameFactory);
            _laserPool = new LaserPool(MaxLaserAmount, _gameFactory);
            _playerController = _gameFactory.CreatePlayer(new UniVector2(), _bulletPool, _laserPool, MaxLaserAmount);

            _randomizer = new Randomizer();
            _sceneManager = new SceneManager();
            _enemyPool = new EnemyPool(EnemySpeed, EnemyAmount, _gameFactory, this, _playerController, EnemyScorePoint);
            _meteorPool = new MeteorPool(
                NormalMeteorSpeed, NormalMeteorAmount, SmallMeteorSpeed, SmallMeteorAmount, 
                _gameFactory, this, NormalMeteorScorePoint, SmallMeteorScorePoint);

            _hazardSpawner = new HazardSpawner(_meteorPool, _enemyPool);

            for (var i = 0; i < EnemyAmount; i++)
                _hazardSpawner.SpawnEnemy();
            
            for (var i = 0; i < NormalMeteorAmount; i++)
                _hazardSpawner.SpawnMeteor(MeteorType.Normal);

            var playerIndicatorHandler = Object.FindObjectOfType<PlayerIndicatorHandler>();
            playerIndicatorHandler.Construct(_playerController);
        }

        public void EnemyDead() => _hazardSpawner.SpawnEnemy();
        
        public void MeteorDead() => _hazardSpawner.SpawnMeteor(MeteorType.Normal);
    }
}