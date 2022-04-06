using Services;
using View;

namespace Logic.Meteor
{
    public class MeteorController
    {
        public MeteorView View { get; }
        public MeteorModel Model { get; }

        private readonly Game _game;

        public MeteorController(MeteorModel meteorModel, MeteorView meteorView, Game game)
        {
            Model = meteorModel;
            View = meteorView;

            _game = game;

            SubscribeOnEvents();
        }

        private void SubscribeOnEvents()
        {
            View.OnMoveRequest += ViewMoveRequest;
            View.OnDead += ViewDead;
            Model.Transform.OnPositionChanged += ModelPositionChanged;
        }

        private void ViewDead()
        {
            Model.Dead();
            Model.Pool.Destroy(this, Model.Type);
            _game.MeteorDead();
        }

        private void ViewMoveRequest(float deltaTime) => 
            Model.Move(deltaTime);

        private void ModelPositionChanged() => 
            View.SetPosition(Model.Transform.Position);
    }
}