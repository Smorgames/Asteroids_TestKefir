using System;
using UnityEngine;

namespace MVC.View.Bullet
{
    public class BulletView : MonoBehaviour
    {
        public Action<float> OnMoveRequest;

        private Vector2 _direction;

        private void FixedUpdate() => 
            OnMoveRequest?.Invoke(Time.fixedDeltaTime);

        public void SetPosition(UniVector2 position) =>
            transform.position = position.ToVector2();
    }
}