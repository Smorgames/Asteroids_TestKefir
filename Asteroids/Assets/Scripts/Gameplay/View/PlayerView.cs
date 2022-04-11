using System;
using ModelLogic.Data;
using Tags;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Gameplay.View
{
    public class PlayerView : MonoBehaviour
    {
        private const string HorizontalAxis = "Horizontal";

        public Action<float, UniVector2> OnRotateRequest;
        public Action<UniVector2> OnLaserFireRequest;
        public Action<float> OnDeltaTimeUpdate;
        public Action OnBulletFireRequest;
        public Action OnAccelerateRequest;
        public Action OnSlowdownRequest;
        public Action OnDead;

        private float _horizontalAxis;
        private bool _needSlowdown = true;
        private bool _needRotate;

        [SerializeField] private Transform _laserSpawnPoint;

        private void Update()
        {
            OnDeltaTimeUpdate?.Invoke(Time.deltaTime);
            
            if (_needSlowdown)
                OnSlowdownRequest?.Invoke();
            else
                OnAccelerateRequest?.Invoke();
            
            if (_needRotate)
                OnRotateRequest?.Invoke(_horizontalAxis, transform.up.ToUniVector2());
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            var enemy = col.GetComponent<EnemyTag>();

            if (enemy != null)
                OnDead?.Invoke();
        }

        public void SetPosition(UniVector2 position) =>
            transform.position = position.ToVector2();

        public void SetRotation(float rotation) =>
            transform.rotation = Quaternion.Euler(0f, 0f, rotation);

        public void MoveForward(InputAction.CallbackContext context)
        {
            if (context.started)
                _needSlowdown = false;
            if (context.canceled)
                _needSlowdown = true;
        }

        public void GunFire(InputAction.CallbackContext context)
        {
            if (context.started)
                OnBulletFireRequest?.Invoke();
        }

        public void LaserFire(InputAction.CallbackContext context)
        {
            if (context.started)
                OnLaserFireRequest?.Invoke(_laserSpawnPoint.position.ToUniVector2());
        }

        public void Rotate(InputAction.CallbackContext context)
        {
            if (context.started) 
                _needRotate = true;
            if (context.canceled)
                _needRotate = false;
            
            if (context.performed)
                _horizontalAxis = -context.ReadValue<float>();
        }
    }
}