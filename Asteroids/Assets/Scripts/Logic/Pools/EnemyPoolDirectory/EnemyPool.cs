using System.Collections.Generic;
using DataContainers;
using Infrastructure.GameDirectory;
using Infrastructure.Services.GameFactoryDirectory;
using Logic.Controllers;
using ScriptableObjects;

namespace Logic.Pools.EnemyPoolDirectory
{
    public class EnemyPool : IEnemyPool
    {
        private const string ContainerName = "Enemies";
        private readonly UniVector2 _spawnPosition = new UniVector2(0f, 1000f);

        private readonly Queue<EnemyController> _pool;

        public EnemyPool(EnemyData data, int poolCapacity, IGameFactory gameFactory, Game game, PlayerController playerController)
        {
            _pool = new Queue<EnemyController>(poolCapacity);
            var container = gameFactory.CreateEmpty(ContainerName);
            data.StartPosition = _spawnPosition;
            for (var i = 0; i < poolCapacity; i++)
            {
                var enemyController = 
                    gameFactory.CreateEnemy(data, playerController.Model, this, game);
                enemyController.View.gameObject.transform.parent = container.transform;
                enemyController.View.gameObject.SetActive(false);
                _pool.Enqueue(enemyController);
            }
        }

        public void Instantiate(UniVector2 startPosition, UniVector2 moveDirection)
        {
            if (_pool.Count == 0) 
                return;

            var enemyController = _pool.Dequeue();
            enemyController.Model.Transform.Position = startPosition;
            enemyController.Model.Transform.Direction = moveDirection;
            enemyController.View.gameObject.SetActive(true);
        }

        public void Destroy(EnemyController enemyController)
        {
            if (enemyController == null)
                return;
            
            _pool.Enqueue(enemyController);
            enemyController.View.gameObject.SetActive(false);
        }
    }
}