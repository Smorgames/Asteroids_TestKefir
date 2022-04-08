using Components;
using DataContainers;
using Enums;
using Infrastructure.Services.Randomizing;
using Logic.Interfaces;
using Logic.Pools.MeteorPoolDirectory;
using ScriptableObjects;

namespace Logic.Models
{
    public class MeteorModel : IScore
    {
        private const int SmallMeteorAmount = 2;
        
        public Transform2D Transform { get; }
        public MeteorType Type { get; }
        public IMeteorPool Pool { get; }

        private readonly Teleport _teleport;
        private readonly MeteorData _meteorData;
        private readonly IRandomizer _randomizer;

        public MeteorModel(MeteorData data, IMeteorPool meteorPool, IRandomizer randomizer)
        {
            _meteorData = data;
            _randomizer = randomizer;
            Pool = meteorPool;
            Type = data.Type;
            Transform = new Transform2D { Position = data.StartPosition };
            _teleport = new Teleport(data.TeleportLimit.X, data.TeleportLimit.Y, Transform);
        }

        public void Move(float deltaTime)
        {
            var newPosition = Transform.Position + Transform.Direction * _meteorData.Speed * deltaTime;
            Transform.Position = newPosition;
            Transform.OnPositionChanged?.Invoke();
            _teleport.TryTeleport();
        }

        public void Dead()
        {
            if (Type == MeteorType.Small)
                return;
            
            for (var i = 0; i < SmallMeteorAmount; i++)
            {
                var randomDirection = new UniVector2(_randomizer.Random(-1f, 1f), _randomizer.Random(-1f, 1f)).Normalize();
                Pool.Instantiate(Transform.Position, randomDirection, MeteorType.Small);
            }
        }

        public int GetScorePoint() => _meteorData.ScorePoint;
    }
}