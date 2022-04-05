﻿using System.Collections.Generic;
using Logic.Enemy;
using Logic.Player;
using Services;

namespace Logic.Pools
{
    public class EnemyPool
    {
        private const string ContainerName = "Enemies";
        private readonly UniVector2 _spawnPosition = new UniVector2(0f, 1000f);

        private readonly Queue<EnemyController> _pool;

        public EnemyPool(float speed, int poolCapacity, GameFactory gameFactory, Game game, PlayerController playerController)
        {
            _pool = new Queue<EnemyController>(poolCapacity);
            var empty = gameFactory.CreateEmpty(ContainerName);
            
            for (var i = 0; i < poolCapacity; i++)
            {
                var enemyController = gameFactory.CreateEnemy(speed, _spawnPosition, playerController.Model, game);
                enemyController.View.gameObject.transform.parent = empty.transform;
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