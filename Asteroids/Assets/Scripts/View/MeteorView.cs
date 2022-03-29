﻿using System;
using UnityEngine;

namespace View
{
    public class MeteorView : MonoBehaviour
    {
        public Action<float> OnMoveRequest;

        private Vector2 _direction;

        private void Update() => 
            OnMoveRequest?.Invoke(Time.deltaTime);

        public void SetPosition(UniVector2 position) => 
            transform.position = position.ToVector2();
    }
}