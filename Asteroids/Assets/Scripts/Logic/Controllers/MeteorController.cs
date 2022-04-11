using DataContainers;
using Enums;
using Infrastructure.GameDirectory;
using Infrastructure.Services.Randomizing;
using Logic.Models;
using Logic.Pools.MeteorPoolDirectory;
using Logic.View;

namespace Logic.Controllers
{
    public class MeteorController
    {
        public MeteorView View { get; }
        public MeteorModel Model { get; }

        private readonly IGame _game;
        private readonly IRandomizer _randomizer;
        private readonly IMeteorPool _meteorPool;

        public MeteorController(MeteorModel meteorModel, MeteorView meteorView, IGame game, IRandomizer randomizer, IMeteorPool meteorPool)
        {
            Model = meteorModel;
            View = meteorView;

            _game = game;
            _randomizer = randomizer;
            _meteorPool = meteorPool;

            SubscribeOnEvents();
        }

        private void SubscribeOnEvents()
        {
            View.OnMoveRequest += ViewMoveRequest;
            View.OnDead += ViewDead;
            
            Model.Transform.OnPositionChanged += ModelPositionChanged;
            Model.OnDead += ModelDead;
        }

        private void ViewDead()
        {
            Model.Dead();
            _meteorPool.Destroy(this, Model.Type);
            _game.MeteorDead(Model);
        }

        private void ViewMoveRequest(float deltaTime) => 
            Model.Move(deltaTime);

        private void ModelPositionChanged() => 
            View.SetPosition(Model.Transform.Position);

        private void ModelDead()
        {
            for (var i = 0; i < Model.SmallMeteorAmount; i++)
            {
                var randomDirection = new UniVector2(_randomizer.Random(-1f, 1f), _randomizer.Random(-1f, 1f)).Normalize();
                _meteorPool.Instantiate(Model.Transform.Position, randomDirection, MeteorType.Small);
            }
        }
    }
}