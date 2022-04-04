using View;

namespace Logic.Enemy
{
    public class EnemyController
    {
        private readonly EnemyModel _enemyModel;
        private readonly EnemyView _enemyView;

        public EnemyController(EnemyModel enemyModel, EnemyView enemyView)
        {
            _enemyModel = enemyModel;
            _enemyView = enemyView;

            SubscribeOnEvents();
        }

        private void SubscribeOnEvents()
        {
            _enemyView.OnMoveRequest += ViewMoveRequest;
            _enemyView.OnRotateRequest += ViewRotateRequest;
            _enemyModel.Transform.OnPositionChanged += ModelPositionChanged;
        }

        private void ViewMoveRequest(float deltaTime) => 
            _enemyModel.Move(deltaTime);

        private void ViewRotateRequest() => 
            _enemyView.SetRotation(_enemyModel.Transform.Direction);

        private void ModelPositionChanged() => 
            _enemyView.SetPosition(_enemyModel.Transform.Position);
    }
}