using System;

namespace MVC.Logic.Bullet
{
    public class BulletModel
    {
        public Action OnPositionChanged;
        
        private float _speed;
        private UniVector2 _position;

        public BulletModel(float speed) => 
            _speed = speed;

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

        public float GetSpeed() => _speed;
    }
}
