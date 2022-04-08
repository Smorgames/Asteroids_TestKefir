﻿using System;
using DataContainers;
using ExtensionsDirectory;
using Logic.Interfaces;
using UnityEngine;

namespace Logic.View
{
    public class MeteorView : MonoBehaviour, IMortal
    {
        public Action<float> OnMoveRequest;
        public Action OnDead;

        private Vector2 _direction;

        private void Update() => 
            OnMoveRequest?.Invoke(Time.deltaTime);

        public void SetPosition(UniVector2 position) => 
            transform.position = position.ToVector2();

        public void Dead() => OnDead?.Invoke();
    }
}