using Infrastructure.GameDirectory;
using Logic.Models;
using Logic.View;

namespace Logic.Controllers
{
    public class MeteorController
    {
        public MeteorView View { get; }
        public MeteorModel Model { get; }

        private readonly IGame _game;

        public MeteorController(MeteorModel meteorModel, MeteorView meteorView, IGame game)
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
            _game.MeteorDead(Model);
        }

        private void ViewMoveRequest(float deltaTime) => 
            Model.Move(deltaTime);

        private void ModelPositionChanged() => 
            View.SetPosition(Model.Transform.Position);
    }
}