using System;
using Components;
using Enums;
using Logic.Interfaces;
using ScriptableObjects;

namespace Logic.Models
{
    public class MeteorModel : IScore
    {
        public Action OnDead;

        public Transform2D Transform { get; }
        public MeteorType Type { get; }
        public int SmallMeteorAmount => 2;

        private readonly Teleport _teleport;
        private readonly MeteorData _meteorData;

        public MeteorModel(MeteorData data)
        {
            _meteorData = data;
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

            OnDead?.Invoke();
        }

        public int GetScorePoint() => _meteorData.ScorePoint;
    }
}