using Gameplay.Controllers;
using Gameplay.Pools.BulletPoolDirectory;
using Gameplay.Pools.EnemyPoolDirectory;
using Gameplay.Pools.LaserPoolDirectory;
using Gameplay.Pools.MeteorPoolDirectory;
using Gameplay.View;
using Infrastructure.Interfaces;
using ModelLogic.Data;
using ModelLogic.Data.Configs;
using ModelLogic.Models;
using UnityEngine;

namespace Infrastructure.Services
{
    public class GameFactory : IGameFactory
    {
        private const string PlayerPath = "PlayerShip";
        private const string MeteorPath = "Meteor";
        private const string SmallMeteorPath = "SmallMeteor";
        private const string BulletPath = "Bullet";
        private const string LaserPath = "Laser";
        private const string EnemyPath = "Enemy";
        
        private readonly IAssetProvider _assetProvider;
        private IGameFactory _gameFactoryImplementation;

        public GameFactory(IAssetProvider assetProvider) => 
            _assetProvider = assetProvider;

        public PlayerController CreatePlayer(PlayerData data, IGame game, IBulletPool bulletPool, ILaserPool laserPool)
        {
            var model = new PlayerModel(data);
            var gunsController = new GunsController(model, laserPool, bulletPool);
            var playerPref = _assetProvider.LoadAsset<PlayerView>(PlayerPath);
            var view = Object.Instantiate(playerPref, data.StartPosition.ToVector2(), Quaternion.identity);
            var controller = new PlayerController(model, view, game);
            return controller;
        }

        public BulletController CreateBullet(BulletData data, IBulletPool bulletPool)
        {
            var model = new BulletModel(data);
            var bulletPref = _assetProvider.LoadAsset<BulletView>(BulletPath);
            var view = Object.Instantiate(bulletPref, data.StartPosition.ToVector2(), Quaternion.identity);
            var controller = new BulletController(model, view, bulletPool);
            return controller;
        }

        public LaserController CreateLaser(UniVector2 startPosition, float rotation, ILaserPool laserPool)
        {
            var model = new LaserModel();
            var laserPref = _assetProvider.LoadAsset<LaserView>(LaserPath);
            var view = Object.Instantiate(laserPref, startPosition.ToVector2(), Quaternion.Euler(0f, 0f, rotation));
            var controller = new LaserController(model, view, laserPool);
            return controller;
        }

        public MeteorController CreateMeteor(MeteorData data, IMeteorPool meteorPool, IGame game, IRandomizer randomizer)
        {
            var model = new MeteorModel(data);
            var meteorPref = _assetProvider.LoadAsset<MeteorView>(MeteorPath);
            var view = Object.Instantiate(meteorPref, data.StartPosition.ToVector2(), Quaternion.identity);
            var controller = new MeteorController(model, view, game, randomizer, meteorPool);
            return controller;
        }

        public EnemyController CreateEnemy(EnemyData data, PlayerModel playerModel, IEnemyPool enemyPool, IGame game)
        {
            var model = new EnemyModel(data, playerModel);
            var enemyPref = _assetProvider.LoadAsset<EnemyView>(EnemyPath);
            var view = Object.Instantiate(enemyPref, data.StartPosition.ToVector2(), Quaternion.identity);
            var controller = new EnemyController(model, view, enemyPool, game);
            return controller;
        }

        public MeteorController CreateSmallMeteor(MeteorData data, IMeteorPool meteorPool, IGame game, IRandomizer randomizer)
        {
            var model = new MeteorModel(data);
            var meteorPref = _assetProvider.LoadAsset<MeteorView>(SmallMeteorPath);
            var view = Object.Instantiate(meteorPref, data.StartPosition.ToVector2(), Quaternion.identity);
            var controller = new MeteorController(model, view, game, randomizer, meteorPool);
            return controller;
        }

        public GameObject CreateEmpty(string name) => new GameObject(name);
    }
}