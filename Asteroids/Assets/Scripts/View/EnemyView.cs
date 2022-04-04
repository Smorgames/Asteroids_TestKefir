using System;
using UnityEngine;

namespace View
{
    public class EnemyView : MonoBehaviour
    {
        public Action<float> OnMoveRequest;
        public Action OnRotateRequest;

        private void Update()
        {
            OnMoveRequest?.Invoke(Time.deltaTime);
            OnRotateRequest?.Invoke();
        }

        public void SetPosition(UniVector2 position) => 
            transform.position = position.ToVector2();

        public void SetRotation(UniVector2 direction)
        {
            var angle = direction.X > 0 
                ? -Vector3.Angle(Vector3.up, direction.ToVector2()) 
                : Vector3.Angle(Vector3.up, direction.ToVector2());
            
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }
    }
}