using System;
using UnityEngine;

namespace MVC.View.Player
{
    public class PlayerView : MonoBehaviour
    {
        private const string HorizontalAxis = "Horizontal";

        public Action<UniVector2> OnMoveRequest;
        public Action<float> OnRotateRequest;

        private void Update()
        {
            if (Input.GetKey(KeyCode.W)) 
                OnMoveRequest?.Invoke(transform.up.ToUniVector2() * Time.deltaTime);

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
                OnRotateRequest?.Invoke(-Input.GetAxis(HorizontalAxis) * Time.deltaTime);
        }

        public void SetPosition(Vector2 position) =>
            transform.position = position;

        public void SetRotation(float rotation) =>
            transform.rotation = Quaternion.Euler(0f, 0f, rotation);
    }
}