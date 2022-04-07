using Data;
using DataContainers;

namespace Logic.Bullet
{
    public class BulletModel
    {
        public Transform2D Transform { get; }

        private readonly BulletData _bulletData;
        
        public BulletModel(BulletData data)
        {
            _bulletData = data;
            Transform = new Transform2D { Position = _bulletData.StartPosition, Direction = _bulletData.StartDirection.Normalize()};
        }

        public void Move(float physicDeltaTime)
        {
            var newPosition = Transform.Position + Transform.Direction * _bulletData.Speed * physicDeltaTime;
            Transform.Position = newPosition;
            Transform.OnPositionChanged?.Invoke();
        }
    }
}