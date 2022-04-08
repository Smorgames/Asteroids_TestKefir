using System;
using DataContainers;
using ExtensionsDirectory;
using Tags;
using UnityEngine;

namespace Logic.View
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

        [SerializeField] private Transform _laserSpawnPoint;

        private void Update()
        {
            
            OnDeltaTimeUpdate?.Invoke(Time.deltaTime);

            if (Input.GetKey(KeyCode.W)) 
                OnAccelerateRequest?.Invoke();
            else
                OnSlowdownRequest?.Invoke();

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
                OnRotateRequest?.Invoke(-Input.GetAxis(HorizontalAxis), transform.up.ToUniVector2());
            
            if (Input.GetKeyDown(KeyCode.J))
                OnBulletFireRequest?.Invoke();

            if (Input.GetKeyDown(KeyCode.L)) 
                OnLaserFireRequest?.Invoke(_laserSpawnPoint.position.ToUniVector2());
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
    }
}