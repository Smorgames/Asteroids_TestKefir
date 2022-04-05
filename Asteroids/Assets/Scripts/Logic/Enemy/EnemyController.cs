using View;

namespace Logic.Enemy
{
    public class EnemyController
    {
        public EnemyView View { get; }

        public EnemyModel Model { get; }

        public EnemyController(EnemyModel enemyModel, EnemyView enemyView)
        {
            Model = enemyModel;
            View = enemyView;

            SubscribeOnEvents();
        }

        private void SubscribeOnEvents()
        {
            View.OnMoveRequest += ViewMoveRequest;
            View.OnRotateRequest += ViewRotateRequest;
            Model.Transform.OnPositionChanged += ModelPositionChanged;
        }

        private void ViewMoveRequest(float deltaTime) => 
            Model.Move(deltaTime);

        private void ViewRotateRequest() => 
            View.SetRotation(Model.Transform.Direction);

        private void ModelPositionChanged() => 
            View.SetPosition(Model.Transform.Position);
    }
}