using System;
using UnityEngine;

namespace MVC.View.Bullet
{
    public class BulletView : MonoBehaviour
    {
        public Action<UniVector2> OnMoveRequest;
        public Action OnShot;
        
        private bool _needMove;
        private Vector2 _direction;

        private void Update()
        {
            if (_needMove) 
                OnMoveRequest?.Invoke(_direction.normalized.ToUniVector2() * Time.deltaTime);
        }

        public void Shot(Vector2 direction)
        {
            _direction = direction;
            _needMove = true;
            OnShot?.Invoke();
        }

        public void SetPosition(UniVector2 position) => 
            transform.position = position.ToVector2();
    }
}