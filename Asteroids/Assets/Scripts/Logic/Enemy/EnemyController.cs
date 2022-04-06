using Logic.Pools;
using Services;
using View;

namespace Logic.Enemy
{
    public class EnemyController
    {
        public EnemyView View { get; }
        public EnemyModel Model { get; }

        private readonly EnemyPool _enemyPool;
        private readonly Game _game;

        public EnemyController(EnemyModel enemyModel, EnemyView enemyView, EnemyPool enemyPool, Game game)
        {
            Model = enemyModel;
            View = enemyView;
            _enemyPool = enemyPool;
            _game = game;
            
            SubscribeOnEvents();
        }

        private void SubscribeOnEvents()
        {
            View.OnMoveRequest += ViewMoveRequest;
            View.OnRotateRequest += ViewRotateRequest;
            View.OnDead += ViewDead;
            Model.Transform.OnPositionChanged += ModelPositionChanged;
        }

        private void ViewMoveRequest(float deltaTime) => 
            Model.Move(deltaTime);

        private void ViewRotateRequest() => 
            View.SetRotation(Model.Transform.Direction);

        private void ViewDead()
        {
            _enemyPool.Destroy(this);
            _game.EnemyDead();
        }

        private void ModelPositionChanged() => 
            View.SetPosition(Model.Transform.Position);
    }
}