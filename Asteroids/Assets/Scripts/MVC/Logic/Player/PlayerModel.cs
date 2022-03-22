using System;

namespace MVC.Logic.Player
{
    public class PlayerModel
    {
        private const float FloatThreshold = 0.001f;
        
        public Action OnPositionChanged;
        public Action OnRotationChanged;

        private UniVector2 _position;
        private float _rotation;
        private float _rotationSpeed = 150f;
        private float _speed = 2f;
        private Gun _gun;

        public void Move(UniVector2 direction)
        {
            var newPosition = _position + direction * _speed;
            SetPosition(newPosition);
        }

        private void SetPosition(UniVector2 position)
        {
            if (Equals(position, _position))
                return;

            _position = position;
            OnPositionChanged?.Invoke();
        }
        
        public void SetPosition(float x, float y) => 
            SetPosition(new UniVector2(x, y));
        
        public UniVector2 GetPosition() => _position;

        public void SetRotation(float rotation)
        {
            if (Math.Abs(_rotation - rotation) < FloatThreshold)
                return;
            
            _rotation = rotation;
            OnRotationChanged?.Invoke();
        }
        public float GetRotation() => _rotation;
        
        public float GetRotationSpeed() => _rotationSpeed;
        
        public float GetSpeed() => _speed;
    }
}