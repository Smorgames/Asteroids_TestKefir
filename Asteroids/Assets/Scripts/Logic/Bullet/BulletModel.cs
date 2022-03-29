using System;
using UnityEngine;

namespace Logic.Bullet
{
    public class BulletModel
    {
        public Action OnPositionChanged;

        public Transform2D Transform { get; }

        private readonly float _speed;

        public BulletModel(float speed, UniVector2 startPosition, UniVector2 moveDirection)
        {
            _speed = speed;
            Transform = new Transform2D(moveDirection.Normalize()) { Position = startPosition };
        }

        public void Move(float physicDeltaTime)
        {
            var newPosition = Transform.Position + Transform.Direction * _speed * physicDeltaTime;
            Transform.Position = newPosition;
            OnPositionChanged?.Invoke();
        }
    }
}