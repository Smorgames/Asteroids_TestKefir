using Data;
using DataContainers;
using Enums;
using Logic;
using Logic.Player;
using Logic.Pools;
using Services.AssetProviding;
using Services.GameObjectCreating;
using Services.Randomizing;
using Services.SceneLoading;
using Services.UICreating;
using UnityEngine;

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
        private readonly FactoryForUI _factoryForUI;
        private readonly Randomizer _randomizer;
        private readonly SceneLoader _sceneLoader;
        private readonly HazardSpawner _hazardSpawner;
        private readonly PlayerController _playerController;
        private readonly LosePanelHandler _losePanelHandler;
        private readonly AssetProvider _assetProvider;

        private readonly BulletPool _bulletPool;
        private readonly EnemyPool _enemyPool;
        private readonly MeteorPool _meteorPool;
        private readonly LaserPool _laserPool;

        private int _score;

        public Game()
        {
            _assetProvider = new AssetProvider();
            _factoryForUI = new FactoryForUI();
            _factoryForUI.CreateEventSystem();
            var camera = _factoryForUI.CreateCamera();
            var canvasComponents = _factoryForUI.CreateMainCanvas(camera);
            
            _gameFactory = new GameFactory(_assetProvider);
            _bulletPool = new BulletPool(BulletAmount, _gameFactory);
            _laserPool = new LaserPool(MaxLaserAmount, _gameFactory);
            var playerData = new PlayerData()
            {
                Speed = 2f,
                RotationSpeed = 150f,
                SlowdownTime = 1f,
                AccelerationLimit = 1f,
                AccelerationTime = 1f,
                LaserReload = 2f,
                MaxLaserAmount = 4,
                StartPosition = new UniVector2(),
                StartDirection = new UniVector2(0f, 1f),
                TeleportLimits = new UniVector2(9.05f, 5.15f)
            };
            _playerController = 
                _gameFactory.CreatePlayer(playerData, _bulletPool, _laserPool, this);

            _randomizer = new Randomizer();
            _sceneLoader = new SceneLoader();

            var enemyData = new EnemyData()
            {
                Speed = EnemySpeed,
                ScorePoint = EnemyScorePoint
            };
            _enemyPool = 
                new EnemyPool(enemyData, EnemyAmount, _gameFactory, this, _playerController);

            var smallMeteorData = new MeteorData()
            {
                ScorePoint = SmallMeteorScorePoint,
                Speed = SmallMeteorSpeed,
                Type = MeteorType.Small,
                TeleportLimit = new UniVector2(9.05f, 5.15f)
            };
            var normalMeteorData = new MeteorData()
            {
                ScorePoint = NormalMeteorScorePoint,
                Speed = NormalMeteorSpeed,
                Type = MeteorType.Normal,
                TeleportLimit = new UniVector2(9.05f, 5.15f)
            };
            _meteorPool = 
                new MeteorPool(normalMeteorData, smallMeteorData, NormalMeteorAmount, SmallMeteorAmount, _gameFactory, this, _randomizer);

            _hazardSpawner = new HazardSpawner(_meteorPool, _enemyPool, _randomizer);

            for (var i = 0; i < EnemyAmount; i++)
                _hazardSpawner.SpawnEnemy();
            
            for (var i = 0; i < NormalMeteorAmount; i++)
                _hazardSpawner.SpawnMeteor(MeteorType.Normal);

            var playerIndicatorHandler = canvasComponents.PlayerIndicatorHandler;
            playerIndicatorHandler.Construct(_playerController);
            _losePanelHandler = canvasComponents.LosePanelHandler;
            _losePanelHandler.Construct(_sceneLoader);
        }

        public void EnemyDead(IScore iScore)
        {
            AddScore(iScore);
            _hazardSpawner.SpawnEnemy();
        }

        public void MeteorDead(IScore iScore)
        {
            AddScore(iScore);
            _hazardSpawner.SpawnMeteor(MeteorType.Normal);
        }

        public void GameOver()
        {
            Time.timeScale = 0f;
            _losePanelHandler.SetScore(_score);
            _losePanelHandler.ShowLosePanel();
        }

        private void AddScore(IScore iScore) => _score += iScore.GetScorePoint();
    }
}