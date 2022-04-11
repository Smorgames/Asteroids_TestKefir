using System;

namespace ModelLogic.Data
{
    public class Transform2D
    {
        public Action OnPositionChanged;
        public Action OnRotationChanged;
        
        private const float FloatThreshold = 0.1f;

        public UniVector2 Position
        {
            get => _position;
            set
            {
                if (Equals(value, _position))
                    return;

                _position = value;
                OnPositionChanged?.Invoke();
            }
        }
        public float Rotation
        {
            get => _rotation;
            set
            {
                if (Math.Abs(_rotation - value) < FloatThreshold)
                    return;

                _rotation = value;
                OnRotationChanged?.Invoke();
            }
        }
        public UniVector2 Direction { get; set; } = new UniVector2(0f, 0f);

        private UniVector2 _position;
        private float _rotation;

        public Transform2D(UniVector2 startPosition, UniVector2 direction)
        {
            Position = startPosition;
            Direction = direction;
        }

        public Transform2D()
        {
            
        }
    }
}