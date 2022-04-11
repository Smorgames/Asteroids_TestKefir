using ModelLogic.Data;
using ModelLogic.Data.Configs;

namespace ModelLogic.Models
{
    public class BulletModel
    {
        public Transform2D Transform { get; }

        private static float _speed;

        public BulletModel(BulletData data)
        {
            _speed = data.Speed;
            Transform = new Transform2D
            {
                Position = data.StartPosition,
                Direction = data.StartDirection.Normalize()
            };
        }

        public void Move(float physicDeltaTime)
        {
            var newPosition = Transform.Position + Transform.Direction * _speed * physicDeltaTime;
            Transform.Position = newPosition;
            Transform.OnPositionChanged?.Invoke();
        }
    }
}