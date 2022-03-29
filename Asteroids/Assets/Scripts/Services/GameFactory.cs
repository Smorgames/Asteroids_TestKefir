using MVC.Logic.Bullet;
using MVC.View;
using UnityEngine;

namespace Services
{
    public class GameFactory
    {
        private const string BulletPath = "Bullet";
        private const string LaserPath = "Laser";

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
    }
}