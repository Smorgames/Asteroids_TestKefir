using ModelLogic.Data;

namespace ModelLogic.Gameplay
{
    public class Teleport
    {
        private const float Offset = 0.05f;
        
        private readonly Transform2D _transform;
        private static float _xLimit;
        private static float _yLimit;

        public Teleport(float xLimit, float yLimit, Transform2D transform)
        {
            _xLimit = xLimit;
            _yLimit = yLimit;
            _transform = transform;
        }

        public void TryTeleport()
        {
            if (_transform.Position.X >= _xLimit)
            {
                _transform.Position.X = -_xLimit + Offset;
                _transform.OnPositionChanged?.Invoke();
            }
            if (_transform.Position.X <= -_xLimit)
            {
                _transform.Position.X = _xLimit - Offset;
                _transform.OnPositionChanged?.Invoke();
            }
            if (_transform.Position.Y >= _yLimit)
            {
                _transform.Position.Y = -_yLimit + Offset;
                _transform.OnPositionChanged?.Invoke();
            }
            if (_transform.Position.Y <= -_yLimit)
            {
                _transform.Position.Y = _yLimit - Offset;
                _transform.OnPositionChanged?.Invoke();
            }
        }
    }
}