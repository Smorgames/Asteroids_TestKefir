using Logic.Player;
using Services;

namespace Logic
{
    public class HazardSpawnerModel
    {
        private readonly PlayerController _playerController;
        private readonly GameFactory _gameFactory;
        private readonly Game _game;
        private float _xLimit = 10f;
        private float _yLimit = 6f;

        private int _meteorCount;
        private int _enemyCount;

        public HazardSpawnerModel(PlayerController playerController, Game game, GameFactory gameFactory)
        {
            _playerController = playerController;
            _gameFactory = gameFactory;
            _game = game;
        }

        public void SpawnEnemy()
        {
            var startPosition = GetRandomSpawnPosition();
            _gameFactory.CreateEnemy(1f, startPosition, _playerController.Model, _game);
        }

        public void SpawnMeteor()
        {
            var startPosition = GetRandomSpawnPosition();
            var moveDirection = GetRandomMoveDirection();
            _gameFactory.CreateMeteor(3f, startPosition, moveDirection);
        }

        private UniVector2 GetRandomSpawnPosition()
        {
            var spawnHorizontally = Randomizer.Random(0f, 1f) > 0.5f;
            var multiplayer =  Randomizer.Random(0f, 1f) > 0.5f ? 1 : -1;

            float x, y;
            
            if (spawnHorizontally)
            {
                x = Randomizer.Random(-_xLimit, _xLimit);
                y = multiplayer * _yLimit;                
            }
            else
            {
                x = multiplayer * _xLimit;
                y = Randomizer.Random(-_yLimit, _yLimit); 
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
