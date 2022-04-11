using Components;
using DataContainers;
using Enums;
using Infrastructure.Services.AssetProviding;
using Infrastructure.Services.GameFactoryDirectory;
using Infrastructure.Services.Math;
using Infrastructure.Services.Randomizing;
using Infrastructure.Services.SceneLoading;
using Infrastructure.Services.TimeScaleManagement;
using Infrastructure.Services.UICreating;
using Logic;
using Logic.Controllers;
using Logic.Interfaces;
using Logic.Pools.BulletPoolDirectory;
using Logic.Pools.EnemyPoolDirectory;
using Logic.Pools.LaserPoolDirectory;
using Logic.Pools.MeteorPoolDirectory;
using Logic.UIHandlers;
using ScriptableObjects;

namespace Infrastructure.GameDirectory
{
    public class Game : IGame
    {
        private const string BulletDataPath = "ScriptableObjects/BulletData";
        private const string PlayerDataPath = "ScriptableObjects/PlayerData";
        private const string EnemyDataPath = "ScriptableObjects/EnemyData";
        private const string NormalMeteorData = "ScriptableObjects/NormalMeteorData";
        private const string SmallMeteorData = "ScriptableObjects/SmallMeteorData";
        private const string EntityAmountData = "ScriptableObjects/EntityAmountData";

        private readonly HazardSpawner _hazardSpawner;
        private LosePanelHandler _losePanelHandler;
        private readonly ITimeScaleManager _timeScaleManager;

        private int _score;

        public Game()
        {
            IMathModule mathModule = new MathModule();
            var initUniVector2 = new UniVector2(mathModule);

            _timeScaleManager = new TimeScaleManager();
            
            IAssetProvider assetProvider = new AssetProvider();
            var bulletData = assetProvider.LoadAsset<BulletData>(BulletDataPath);
            var playerData = assetProvider.LoadAsset<PlayerData>(PlayerDataPath);
            var enemyData = assetProvider.LoadAsset<EnemyData>(EnemyDataPath);
            var normalMeteorData = assetProvider.LoadAsset<MeteorData>(NormalMeteorData);
            var smallMeteorData = assetProvider.LoadAsset<MeteorData>(SmallMeteorData);
            var entityAmountData = assetProvider.LoadAsset<EntityAmountData>(EntityAmountData);
            
            
            IFactoryForUI factoryForUI = new FactoryForUI();
            var canvasComponents = factoryForUI.CreateUIGameSetup();

            IGameFactory gameFactory = new GameFactory(assetProvider);
            
            IBulletPool bulletPool = new BulletPool(entityAmountData.BulletAmount, gameFactory, bulletData);
            ILaserPool laserPool = new LaserPool(playerData.MaxLaserAmount, gameFactory);
            var playerController = gameFactory.CreatePlayer(playerData, this, bulletPool, laserPool);

            IRandomizer randomizer = new Randomizer();
            
            
            ISceneLoader sceneLoader = new SceneLoader(_timeScaleManager);
            
            IEnemyPool enemyPool = new EnemyPool(enemyData, entityAmountData.EnemyAmount, gameFactory, this, playerController);
            
            IMeteorPool meteorPool = new MeteorPool(normalMeteorData, smallMeteorData, 
                entityAmountData.NormalMeteorAmount, entityAmountData.SmallMeteorAmount, gameFactory,
                this, randomizer);

            _hazardSpawner = new HazardSpawner(meteorPool, enemyPool, randomizer);

            SpawnHazards(entityAmountData);
            SetHandlersForUI(canvasComponents, playerController, sceneLoader);
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
            _timeScaleManager.SetTimeScale(0f);
            _losePanelHandler.SetScore(_score);
            _losePanelHandler.ShowLosePanel();
        }

        private void AddScore(IScore iScore) => 
            _score += iScore.GetScorePoint();

        private void SetHandlersForUI(CanvasComponents canvasComponents, PlayerController playerController, ISceneLoader sceneLoader)
        {
            var playerIndicatorHandler = canvasComponents.PlayerIndicatorHandler;
            playerIndicatorHandler.Construct(playerController);
            _losePanelHandler = canvasComponents.LosePanelHandler;
            _losePanelHandler.Construct(sceneLoader);
        }

        private void SpawnHazards(EntityAmountData entityAmountData)
        {
            for (var i = 0; i < entityAmountData.EnemyAmount; i++)
                _hazardSpawner.SpawnEnemy();

            for (var i = 0; i < entityAmountData.NormalMeteorAmount; i++)
                _hazardSpawner.SpawnMeteor(MeteorType.Normal);
        }
    }
}