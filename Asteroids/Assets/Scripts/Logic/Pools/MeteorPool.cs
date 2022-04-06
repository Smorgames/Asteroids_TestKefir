using System.Collections.Generic;
using DataStructers;
using Enums;
using Logic.Meteor;
using Services;

namespace Logic.Pools
{
    public class MeteorPool
    {
        private const string SmallMeteorContainerName = "SmallMeteors";
        private const string NormalMeteorContainerName = "NormalMeteors";
        private readonly UniVector2 _spawnPosition = new UniVector2(0f, 1000f);

        private readonly Queue<MeteorController> _smallMeteorPool;
        private readonly Queue<MeteorController> _normalMeteorPool;

        public MeteorPool(float normalMeteorSpeed, int normalMeteorPoolCapacity, float smallMeteorSpeed, int smallMeteorPoolCapacity, 
            GameFactory gameFactory, Game game, int normalMeteorScorePoint, int smallMeteorScorePoint)
        {
            _normalMeteorPool = new Queue<MeteorController>(normalMeteorPoolCapacity);
            _smallMeteorPool = new Queue<MeteorController>(smallMeteorPoolCapacity);

            var normalMeteorContainer = gameFactory.CreateEmpty(NormalMeteorContainerName);
            var smallMeteorContainer = gameFactory.CreateEmpty(SmallMeteorContainerName);

            for (var i = 0; i < normalMeteorPoolCapacity; i++)
            {
                var normalMeteorController = gameFactory.CreateMeteor(normalMeteorSpeed, _spawnPosition, new UniVector2(), this, game, normalMeteorScorePoint);
                normalMeteorController.View.gameObject.transform.parent = normalMeteorContainer.transform;
                normalMeteorController.View.gameObject.SetActive(false);
                _normalMeteorPool.Enqueue(normalMeteorController);
            }

            for (var i = 0; i < smallMeteorPoolCapacity; i++)
            {
                var smallMeteorController = gameFactory.CreateSmallMeteor(smallMeteorSpeed, _spawnPosition, new UniVector2(), this, game, smallMeteorScorePoint);
                smallMeteorController.View.gameObject.transform.parent = smallMeteorContainer.transform;
                smallMeteorController.View.gameObject.SetActive(false);
                _smallMeteorPool.Enqueue(smallMeteorController);
            }
        }

        public void Instantiate(UniVector2 startPosition, UniVector2 moveDirection, MeteorType type)
        {
            Queue<MeteorController> pool;
            
            if (type == MeteorType.Normal)
            {
                if (_normalMeteorPool.Count == 0) 
                    return;

                pool = _normalMeteorPool;
            }
            else
            {
                if (_smallMeteorPool.Count == 0) 
                    return;

                pool = _smallMeteorPool;
            }
            
            var meteorController = pool.Dequeue();
            meteorController.Model.Transform.Position = startPosition;
            meteorController.Model.Transform.Direction = moveDirection;
            meteorController.View.gameObject.SetActive(true);
        }

        public void Destroy(MeteorController meteorController, MeteorType type)
        {
            if (meteorController == null)
                return;

            var pool = type == MeteorType.Normal ? _normalMeteorPool : _smallMeteorPool;

            pool.Enqueue(meteorController);
            meteorController.View.gameObject.SetActive(false);
        }
    }
}