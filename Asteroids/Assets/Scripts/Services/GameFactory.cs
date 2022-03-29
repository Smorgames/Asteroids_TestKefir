using MVC.Logic.Bullet;
using MVC.View.Bullet;
using UnityEngine;

namespace Services
{
    public class GameFactory
    {
        private const string BulletPath = "Bullet";

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
    }
}