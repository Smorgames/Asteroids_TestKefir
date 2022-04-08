using System;
using System.Collections;
using DataContainers;
using ExtensionsDirectory;
using Logic.Interfaces;
using Tags;
using UnityEngine;

namespace Logic.View
{
    public class BulletView : MonoBehaviour
    {
        
        public Action<float> OnMoveRequest;
        public Action OnDead;
        
        private Vector2 _direction;
        private readonly WaitForSeconds _waitBeforeDead = new WaitForSeconds(4f);

        private void Update() =>
            OnMoveRequest?.Invoke(Time.deltaTime);

        private void OnTriggerEnter2D(Collider2D col)
        {
            var enemy = col.GetComponent<EnemyTag>();

            if (enemy != null)
            {
                enemy.GetComponent<IMortal>()?.Dead();
                OnDead?.Invoke();
            }
        }


        public void SetPosition(UniVector2 position) =>
            transform.position = position.ToVector2();

        public void DestroyOnTimer() => StartCoroutine(DestroyOnTimerCoroutine());

        private IEnumerator DestroyOnTimerCoroutine()
        {
            yield return _waitBeforeDead;
            OnDead?.Invoke();
        }
    }
}