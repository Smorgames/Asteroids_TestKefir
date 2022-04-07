using System;
using DataContainers;
using ExtensionsDirectory;
using Logic;
using UnityEngine;

namespace View
{
    public class EnemyView : MonoBehaviour, IMortal
    {
        public Action<float> OnMoveRequest;
        public Action OnRotateRequest;
        public Action OnDead;

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

        public void Dead() => OnDead?.Invoke();
    }
}