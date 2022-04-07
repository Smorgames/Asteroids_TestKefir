using System.Collections.Generic;
using Data;
using DataContainers;
using Logic.Bullet;
using Services;
using Services.GameObjectCreating;

namespace Logic.Pools
{
    public class BulletPool
    {
        private const string ContainerName = "Bullets";
        private readonly UniVector2 _spawnPosition = new UniVector2(1000f, 1000f);

        private readonly Queue<BulletController> _pool;

        public BulletPool(int poolCapacity, GameFactory gameFactory, BulletData data)
        {
            _pool = new Queue<BulletController>(poolCapacity);
            var empty = gameFactory.CreateEmpty(ContainerName);

            for (var i = 0; i < poolCapacity; i++)
            {
                data.StartPosition = _spawnPosition;
                var bulletController = gameFactory.CreateBullet(data, this);
                bulletController.View.gameObject.transform.parent = empty.transform;
                bulletController.View.gameObject.SetActive(false);
                _pool.Enqueue(bulletController);
            }
        }

        public void Instantiate(UniVector2 startPosition, UniVector2 moveDirection)
        {
            if (_pool.Count == 0)
                return;

            var bulletController = _pool.Dequeue();
            bulletController.Model.Transform.Position = startPosition;
            bulletController.Model.Transform.Direction = moveDirection;
            bulletController.View.gameObject.SetActive(true);
            bulletController.View.DestroyOnTimer();
        }

        public void Destroy(BulletController bulletController)
        {
            if (bulletController == null)
                return;

            _pool.Enqueue(bulletController);
            bulletController.View.gameObject.SetActive(false);
        }
    }
}