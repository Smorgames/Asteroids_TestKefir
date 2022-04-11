using System;

namespace Logic.Models
{
    public class BulletGunModel
    {
        public Action OnFire;

        public void Fire() => OnFire?.Invoke();
    }
}