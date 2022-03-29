using System;
using UnityEngine;

namespace MVC.View
{
    public class PlayerView : MonoBehaviour
    {
        private const string HorizontalAxis = "Horizontal";

        public Action<float> OnDeltaTimeUpdate;
        public Action OnMoveRequest;
        public Action<float, UniVector2> OnRotateRequest;
        public Action OnBulletFireRequest;
        public Action<UniVector2> OnLaserFireRequest;

        [SerializeField] private Transform _laserSpawnPoint;

        private void Update()
        {
            OnDeltaTimeUpdate?.Invoke(Time.deltaTime);

            if (Input.GetKey(KeyCode.W)) 
                OnMoveRequest?.Invoke();

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
                OnRotateRequest?.Invoke(-Input.GetAxis(HorizontalAxis), transform.up.ToUniVector2());
            
            if (Input.GetKeyDown(KeyCode.J))
                OnBulletFireRequest?.Invoke();

            if (Input.GetKeyDown(KeyCode.L)) 
                OnLaserFireRequest?.Invoke(_laserSpawnPoint.position.ToUniVector2());
        }
        
        public void SetPosition(UniVector2 position) =>
            transform.position = position.ToVector2();

        public void SetRotation(float rotation) =>
            transform.rotation = Quaternion.Euler(0f, 0f, rotation);
    }
}