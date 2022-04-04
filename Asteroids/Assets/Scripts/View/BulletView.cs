using System;
using Logic;
using UnityEngine;

namespace View
{
    public class BulletView : MonoBehaviour
    {
        public Action<float> OnMoveRequest;

        private Vector2 _direction;

        private void Update() =>
            OnMoveRequest?.Invoke(Time.deltaTime);

        private void OnTriggerEnter2D(Collider2D col)
        {
            var enemy = col.GetComponent<EnemyTag>();

            if (enemy != null)
            {
                Destroy(enemy.gameObject);
                Destroy(gameObject);
            }
        }

        public void SetPosition(UniVector2 position) =>
            transform.position = position.ToVector2();
    }
}