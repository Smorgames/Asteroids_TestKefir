using Gameplay.View;
using Infrastructure.Interfaces;
using ModelLogic.Data;
using ModelLogic.Models;

namespace Gameplay.Controllers
{
    public class PlayerController
    {
        public PlayerModel Model { get; }
        private PlayerView View { get; }

        private readonly IGame _game;

        public PlayerController(PlayerModel playerModel, PlayerView playerView, IGame game)
        {
            Model = playerModel;
            View = playerView;
            _game = game;
            
            SubscribeOnEvents();
        }

        private void SubscribeOnEvents()
        {
            View.OnAccelerateRequest += ViewAccelerateRequest;
            View.OnSlowdownRequest += ViewSlowdownRequest;
            View.OnRotateRequest += ViewRotateRequest;
            View.OnBulletFireRequest += ViewBulletFireRequest;
            View.OnLaserFireRequest += ViewLaserFireRequest;
            View.OnDeltaTimeUpdate += ViewUpdate;
            View.OnDead += ViewDead;
            
            Model.Transform.OnPositionChanged += ModelPositionChanged;
            Model.Transform.OnRotationChanged += ModelRotationChanged;
        }

        private void ViewAccelerateRequest() => Model.Accelerate();

        private void ViewSlowdownRequest() => Model.Slowdown();

        private void ViewRotateRequest(float horizontalAxis, UniVector2 moveDirection)
        {
            Model.Rotate(horizontalAxis);
            Model.Transform.Direction = moveDirection;
        }
        
        private void ViewBulletFireRequest() => Model.FireBulletGun();
        
        private void ViewLaserFireRequest(UniVector2 laserSpawnPosition) => 
            Model.FireLaserGun(laserSpawnPosition);
        
        private void ViewUpdate(float deltaTime)
        {
            Model.DeltaTime = deltaTime;
            Model.OnUpdate?.Invoke();
        }
        
        private void ViewDead() => _game.GameOver();

        private void ModelPositionChanged() => 
            View.SetPosition(Model.Transform.Position);
        
        private void ModelRotationChanged() => 
            View.SetRotation(Model.Transform.Rotation);
    }
}