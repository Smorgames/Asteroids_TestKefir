using DataStructers;
using Enums;
using ExtensionsDirectory;
using Logic.Bullet;
using Logic.Enemy;
using Logic.Laser;
using Logic.Meteor;
using Logic.Player;
using Logic.Pools;
using UnityEngine;
using View;

namespace Services
{
    public class GameFactory
    {
        private const string PlayerPath = "PlayerShip";
        private const string MeteorPath = "Meteor";
        private const string SmallMeteorPath = "SmallMeteor";
        private const string BulletPath = "Bullet";
        private const string LaserPath = "Laser";
        private const string EnemyPath = "Enemy";

        private const float BulletSpeed = 10f;

        public PlayerController CreatePlayer(UniVector2 startPosition, BulletPool bulletPool, LaserPool laserPool,
            int maxLaserAmount)
        {
            var model = new PlayerModel(startPosition, bulletPool, laserPool, maxLaserAmount);
            var playerPref = Resources.Load<PlayerView>(PlayerPath);
            var view = Object.Instantiate(playerPref, startPosition.ToVector2(), Quaternion.identity);
            var controller = new PlayerController(model, view);
            return controller;
        }

        public BulletController CreateBullet(UniVector2 startPosition, UniVector2 moveDirection, BulletPool bulletPool)
        {
            var model = new BulletModel(BulletSpeed, startPosition, moveDirection);
            var bulletPref = Resources.Load<BulletView>(BulletPath);
            var view = Object.Instantiate(bulletPref, startPosition.ToVector2(), Quaternion.identity);
            var controller = new BulletController(model, view, bulletPool);
            return controller;
        }

        public LaserController CreateLaser(UniVector2 startPosition, float rotation, LaserPool laserPool)
        {
            var model = new LaserModel();
            var laserPref = Resources.Load<LaserView>(LaserPath);
            var view = Object.Instantiate(laserPref, startPosition.ToVector2(), Quaternion.Euler(0f, 0f, rotation));
            var controller = new LaserController(model, view, laserPool);
            return controller;
        }

        public MeteorController CreateMeteor(float speed, UniVector2 startPosition, UniVector2 moveDirection,
            MeteorPool meteorPool, Game game, int scorePoint)
        {
            var model = new MeteorModel(speed, startPosition, moveDirection, MeteorType.Normal, meteorPool, scorePoint);
            var meteorPref = Resources.Load<MeteorView>(MeteorPath);
            var view = Object.Instantiate(meteorPref, startPosition.ToVector2(), Quaternion.identity);
            var controller = new MeteorController(model, view, game);
            return controller;
        }

        public EnemyController CreateEnemy(float speed, UniVector2 startPosition, PlayerModel playerModel,
            EnemyPool enemyPool, Game game, int scorePoint)
        {
            var model = new EnemyModel(speed, startPosition, playerModel, scorePoint);
            var enemyPref = Resources.Load<EnemyView>(EnemyPath);
            var view = Object.Instantiate(enemyPref, startPosition.ToVector2(), Quaternion.identity);
            var controller = new EnemyController(model, view, enemyPool, game);
            return controller;
        }

        public MeteorController CreateSmallMeteor(float speed, UniVector2 startPosition, UniVector2 moveDirection,
            MeteorPool meteorPool, Game game, int scorePoint)
        {
            var model = new MeteorModel(speed, startPosition, moveDirection, MeteorType.Small, meteorPool, scorePoint);
            var meteorPref = Resources.Load<MeteorView>(SmallMeteorPath);
            var view = Object.Instantiate(meteorPref, startPosition.ToVector2(), Quaternion.identity);
            var controller = new MeteorController(model, view, game);
            return controller;
        }

        public GameObject CreateEmpty(string name) => new GameObject(name);
    }
}