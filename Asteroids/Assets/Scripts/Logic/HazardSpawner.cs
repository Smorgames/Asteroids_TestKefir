using DataStructers;
using Enums;
using Logic.Pools;
using Services;

namespace Logic
{
    public class HazardSpawner
    {
        private const float XLimit = 14f;
        private const float YLimit = 9f;

        private readonly GameFactory _gameFactory;
        private readonly EnemyPool _enemyPool;
        private readonly MeteorPool _meteorPool;
        
        public HazardSpawner(MeteorPool meteorPool, EnemyPool enemyPool)
        {
            _meteorPool = meteorPool;
            _enemyPool = enemyPool;
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
            var spawnHorizontally = Randomizer.Random(0f, 1f) > 0.5f;
            var multiplayer = Randomizer.Random(0f, 1f) > 0.5f ? 1 : -1;

            float x, y;

            if (spawnHorizontally)
            {
                x = Randomizer.Random(-XLimit, XLimit);
                y = multiplayer * YLimit;
            }
            else
            {
                x = multiplayer * XLimit;
                y = Randomizer.Random(-YLimit, YLimit);
            }

            return new UniVector2(x, y);
        }

        private UniVector2 GetRandomMoveDirection()
        {
            var x = Randomizer.Random(-1f, 1f);
            var y = Randomizer.Random(-1f, 1f);

            return new UniVector2(x, y).Normalize();
        }
    }
}