using Gameplay.Pools.EnemyPoolDirectory;
using Gameplay.Pools.MeteorPoolDirectory;
using Infrastructure.Interfaces;
using ModelLogic.Data;
using ModelLogic.Data.Enums;

namespace Gameplay
{
    public class HazardSpawner
    {
        private const float XLimit = 14f;
        private const float YLimit = 9f;

        private readonly IEnemyPool _enemyPool;
        private readonly IMeteorPool _meteorPool;
        private readonly IRandomizer _randomizer;
        
        public HazardSpawner(IMeteorPool meteorPool, IEnemyPool enemyPool, IRandomizer randomizer)
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