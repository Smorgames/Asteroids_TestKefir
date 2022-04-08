using System.Collections.Generic;
using DataContainers;
using Infrastructure.Services.GameFactoryDirectory;
using Logic.Controllers;

namespace Logic.Pools.LaserPoolDirectory
{
    public class LaserPool : ILaserPool
    {
        private const string ContainerName = "Lasers";
        private const float StartRotation = 0f;
        private readonly UniVector2 _spawnPosition = new UniVector2(1000f, 1000f);

        private readonly Queue<LaserController> _pool;

        public LaserPool(int poolCapacity, IGameFactory gameFactory)
        {
            _pool = new Queue<LaserController>(poolCapacity);
            var container = gameFactory.CreateEmpty(ContainerName);
            
            for (var i = 0; i < poolCapacity; i++)
            {
                var laserController = gameFactory.CreateLaser(_spawnPosition, StartRotation, this);
                laserController.View.gameObject.transform.parent = container.transform;
                laserController.View.gameObject.SetActive(false);
                _pool.Enqueue(laserController);
            }
        }

        public void Instantiate(UniVector2 startPosition, float angle)
        {
            if (_pool.Count == 0)
                return;

            var laserController = _pool.Dequeue();
            laserController.View.gameObject.SetActive(true);
            laserController.Model.SetPosition(startPosition);
            laserController.Model.SetRotation(angle);
            laserController.View.DestroyOnTimer();
        }

        public void Destroy(LaserController laserController)
        {
            if (laserController == null)
                return;

            laserController.Model.SetPosition(_spawnPosition);
            _pool.Enqueue(laserController);
            laserController.View.gameObject.SetActive(false);
        }
    }
}