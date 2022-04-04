using Logic.Bullet;
using Logic.Enemy;
using Logic.Meteor;
using Logic.Player;
using Unity.VisualScripting;
using UnityEngine;
using View;

namespace Services
{
    public class GameFactory
    {
        private const string MeteorPath = "Meteor";
        private const string BulletPath = "Bullet";
        private const string LaserPath = "Laser";
        private const string EnemyPath = "Enemy";

        public void CreatePlayer()
        {
            
        }

        public static BulletController CreateBullet(UniVector2 startPosition, UniVector2 moveDirection)
        {
            var model = new BulletModel(10f, startPosition, moveDirection);
            var bulletPref = Resources.Load<BulletView>(BulletPath);
            var view = Object.Instantiate(bulletPref, startPosition.ToVector2(), Quaternion.identity);
            var controller = new BulletController(model, view);
            return controller;
        }

        public static void CreateLaser(UniVector2 startPosition, float rotation)
        {
            var laserPref = Resources.Load<LaserView>(LaserPath);
            var view = Object.Instantiate(laserPref, startPosition.ToVector2(), Quaternion.Euler(0f, 0f, rotation));
        }

        public static void CreateMeteor(float speed, UniVector2 startPosition, UniVector2 moveDirection)
        {
            var model = new MeteorModel(speed, startPosition, moveDirection);
            var meteorPref = Resources.Load<MeteorView>(MeteorPath);
            var view = Object.Instantiate(meteorPref, startPosition.ToVector2(), Quaternion.identity);
            var controller = new MeteorController(model, view);
        }

        public static void CreateEnemy(float speed, UniVector2 startPosition, PlayerModel playerModel)
        {
            var model = new EnemyModel(speed, startPosition, playerModel);
            var enemyPref = Resources.Load<EnemyView>(EnemyPath);
            var view = Object.Instantiate(enemyPref, startPosition.ToVector2(), Quaternion.identity);
            var controller = new EnemyController(model, view);
        }
    }
}