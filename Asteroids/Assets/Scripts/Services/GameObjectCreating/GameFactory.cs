using Data;
using DataContainers;
using ExtensionsDirectory;
using Logic.Bullet;
using Logic.Enemy;
using Logic.Laser;
using Logic.Meteor;
using Logic.Player;
using Logic.Pools;
using Services.AssetProviding;
using Services.Randomizing;
using UnityEngine;
using View;

namespace Services.GameObjectCreating
{
    public class GameFactory
    {
        private const string PlayerPath = "PlayerShip";
        private const string MeteorPath = "Meteor";
        private const string SmallMeteorPath = "SmallMeteor";
        private const string BulletPath = "Bullet";
        private const string LaserPath = "Laser";
        private const string EnemyPath = "Enemy";
        
        private readonly AssetProvider _assetProvider;

        public GameFactory(AssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public PlayerController CreatePlayer(PlayerData data, BulletPool bulletPool, LaserPool laserPool, Game game)
        {
            var model = new PlayerModel(data, bulletPool, laserPool);
            var playerPref = _assetProvider.LoadAsset<PlayerView>(PlayerPath);
            var view = Object.Instantiate(playerPref, data.StartPosition.ToVector2(), Quaternion.identity);
            var controller = new PlayerController(model, view, game);
            return controller;
        }

        public BulletController CreateBullet(BulletData data, BulletPool bulletPool)
        {
            var model = new BulletModel(data);
            var bulletPref = _assetProvider.LoadAsset<BulletView>(BulletPath);
            var view = Object.Instantiate(bulletPref, data.StartPosition.ToVector2(), Quaternion.identity);
            var controller = new BulletController(model, view, bulletPool);
            return controller;
        }

        public LaserController CreateLaser(UniVector2 startPosition, float rotation, LaserPool laserPool)
        {
            var model = new LaserModel();
            var laserPref = _assetProvider.LoadAsset<LaserView>(LaserPath);
            var view = Object.Instantiate(laserPref, startPosition.ToVector2(), Quaternion.Euler(0f, 0f, rotation));
            var controller = new LaserController(model, view, laserPool);
            return controller;
        }

        public MeteorController CreateMeteor(MeteorData data, MeteorPool meteorPool, Game game, Randomizer randomizer)
        {
            var model = new MeteorModel(data, meteorPool, randomizer);
            var meteorPref = _assetProvider.LoadAsset<MeteorView>(MeteorPath);
            var view = Object.Instantiate(meteorPref, data.StartPosition.ToVector2(), Quaternion.identity);
            var controller = new MeteorController(model, view, game);
            return controller;
        }

        public EnemyController CreateEnemy(EnemyData data, UniVector2 startPosition, PlayerModel playerModel, 
            EnemyPool enemyPool, Game game)
        {
            var model = new EnemyModel(data, playerModel);
            var enemyPref = _assetProvider.LoadAsset<EnemyView>(EnemyPath);
            var view = Object.Instantiate(enemyPref, startPosition.ToVector2(), Quaternion.identity);
            var controller = new EnemyController(model, view, enemyPool, game);
            return controller;
        }

        public MeteorController CreateSmallMeteor(MeteorData data, MeteorPool meteorPool, Game game, Randomizer randomizer)
        {
            var model = new MeteorModel(data, meteorPool, randomizer);
            var meteorPref = _assetProvider.LoadAsset<MeteorView>(SmallMeteorPath);
            var view = Object.Instantiate(meteorPref, data.StartPosition.ToVector2(), Quaternion.identity);
            var controller = new MeteorController(model, view, game);
            return controller;
        }

        public GameObject CreateEmpty(string name) => new GameObject(name);
    }
}