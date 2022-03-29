using System;
using UnityEngine;

namespace MVC.View.Player
{
    public class PlayerView : MonoBehaviour
    {
        private const string HorizontalAxis = "Horizontal";

        public Action OnMoveRequest;
        public Action<float, UniVector2> OnRotateRequest;
        public Action OnBulletFireRequest;
        public Action<float> OnDeltaTimeUpdate;

        private void Update()
        {
            OnDeltaTimeUpdate?.Invoke(Time.deltaTime);

            if (Input.GetKey(KeyCode.W)) 
                OnMoveRequest?.Invoke();

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
                OnRotateRequest?.Invoke(-Input.GetAxis(HorizontalAxis), transform.up.ToUniVector2());
            
            if (Input.GetKeyDown(KeyCode.J))
                OnBulletFireRequest?.Invoke();
        }

        public void SetPosition(UniVector2 position) =>
            transform.position = position.ToVector2();

        public void SetRotation(float rotation) =>
            transform.rotation = Quaternion.Euler(0f, 0f, rotation);
    }
}