using DataContainers;
using Enums;
using Logic.Pools;
using Services;
using Services.GameObjectCreating;
using Services.Randomizing;

namespace Logic
{
    public class HazardSpawner
    {
        private const float XLimit = 14f;
        private const float YLimit = 9f;

        private readonly GameFactory _gameFactory;
        private readonly EnemyPool _enemyPool;
        private readonly MeteorPool _meteorPool;
        private readonly Randomizer _randomizer;
        
        public HazardSpawner(MeteorPool meteorPool, EnemyPool enemyPool, Randomizer randomizer)
        {
            _meteorPool = meteorPool;
            _enemyPool = enemyPool;
            _randomizer = randomizer;
        }

        public void SpawnEnemy()
        {
            var startPosition = GetRandomSpawnPosition();
            _enemyPool.Instantiate(startPosition, new UniVector2());
        }

        public void SpawnMeteor(MeteorType type)
        {
            var startPosition = GetRandomSpawnPosition();
            var moveDirection = GetRandomMoveDirection();
            _meteorPool.Instantiate(startPosition, moveDirection, type);
        }

        private UniVector2 GetRandomSpawnPosition()
        {
            var spawnHorizontally = _randomizer.Random(0f, 1f) > 0.5f;
            var multiplayer = _randomizer.Random(0f, 1f) > 0.5f ? 1 : -1;

            float x, y;

            if (spawnHorizontally)
            {
                x = _randomizer.Random(-XLimit, XLimit);
                y = multiplayer * YLimit;
            }
            else
            {
                x = multiplayer * XLimit;
                y = _randomizer.Random(-YLimit, YLimit);
            }

            return new UniVector2(x, y);
        }

        private UniVector2 GetRandomMoveDirection()
        {
            var x = _randomizer.Random(-1f, 1f);
            var y = _randomizer.Random(-1f, 1f);

            return new UniVector2(x, y).Normalize();
        }
    }
}