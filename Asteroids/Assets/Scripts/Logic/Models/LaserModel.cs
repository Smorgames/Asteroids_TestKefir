using Components;
using DataContainers;

namespace Logic.Models
{
    public class LaserModel
    {
        public Transform2D Transform { get; }

        public LaserModel() => 
            Transform = new Transform2D();

        public void SetPosition(UniVector2 position)
        {
            Transform.Position = position;
            Transform.OnPositionChanged?.Invoke();
        }

        public void SetRotation(float angle)
        {
            Transform.Rotation = angle;
            Transform.OnRotationChanged?.Invoke();
        }
    }
}