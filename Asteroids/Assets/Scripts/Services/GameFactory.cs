using Logic;
using Logic.Bullet;
using Logic.Enemy;
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

        public PlayerController CreatePlayer(UniVector2 startPosition, BulletPool bulletPool)
        {
            var model = new PlayerModel(startPosition, bulletPool, this);
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

        public void CreateLaser(UniVector2 startPosition, float rotation)
        {
            var laserPref = Resources.Load<LaserView>(LaserPath);
            var view = Object.Instantiate(laserPref, startPosition.ToVector2(), Quaternion.Euler(0f, 0f, rotation));
        }

        public MeteorController CreateMeteor(float speed, UniVector2 startPosition, UniVector2 moveDirection)
        {
            var model = new MeteorModel(speed, startPosition, moveDirection, MeteorType.Normal, this);
            var meteorPref = Resources.Load<MeteorView>(MeteorPath);
            var view = Object.Instantiate(meteorPref, startPosition.ToVector2(), Quaternion.identity);
            var controller = new MeteorController(model, view);
            return controller;
        }

        public EnemyController CreateEnemy(float speed, UniVector2 startPosition, PlayerModel playerModel, Game game)
        {
            var model = new EnemyModel(speed, startPosition, playerModel, game);
            var enemyPref = Resources.Load<EnemyView>(EnemyPath);
            var view = Object.Instantiate(enemyPref, startPosition.ToVector2(), Quaternion.identity);
            var controller = new EnemyController(model, view);
            return controller;
        }

        public void CreateSmallMeteor(float speed, UniVector2 startPosition, UniVector2 moveDirection)
        {
            var model = new MeteorModel(speed, startPosition, moveDirection, MeteorType.Small, this);
            var meteorPref = Resources.Load<MeteorView>(SmallMeteorPath);
            var view = Object.Instantiate(meteorPref, startPosition.ToVector2(), Quaternion.identity);
            var controller = new MeteorController(model, view);
        }

        public GameObject CreateEmpty(string name) => new GameObject(name);
    }
}