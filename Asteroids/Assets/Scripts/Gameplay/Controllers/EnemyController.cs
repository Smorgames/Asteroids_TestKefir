using Gameplay.Pools.EnemyPoolDirectory;
using Gameplay.View;
using Infrastructure.Interfaces;
using ModelLogic.Models;

namespace Gameplay.Controllers
{
    public class EnemyController
    {
        public EnemyView View { get; }
        public EnemyModel Model { get; }

        private readonly IEnemyPool _enemyPool;
        private readonly IGame _game;

        public EnemyController(EnemyModel enemyModel, EnemyView enemyView, IEnemyPool enemyPool, IGame game)
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
            _game.EnemyDead(Model);
        }

        private void ModelPositionChanged() => 
            View.SetPosition(Model.Transform.Position);
    }
}