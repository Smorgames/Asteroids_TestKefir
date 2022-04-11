using System;

namespace ModelLogic.Models
{
    public class BulletGunModel
    {
        public Action OnFire;

        public void Fire() => OnFire?.Invoke();
    }
}