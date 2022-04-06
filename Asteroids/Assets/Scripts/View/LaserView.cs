using System;
using System.Collections;
using DataStructers;
using ExtensionsDirectory;
using Logic;
using Tags;
using UnityEngine;

namespace View
{
    public class LaserView : MonoBehaviour
    {
        private const float ZeroAngle = 0f;
        private readonly WaitForSeconds _waitBeforeDestroy = new WaitForSeconds(0.25f);
        
        public Action OnDead;

        private void OnTriggerEnter2D(Collider2D col)
        {
            var enemy = col.GetComponent<EnemyTag>();

            if (enemy != null) 
                enemy.GetComponent<IMortal>().Dead();
        }

        public void SetPosition(UniVector2 position) => 
            transform.position = position.ToVector2();

        public void SetRotation(float angle) =>
            transform.rotation = Quaternion.Euler(ZeroAngle, ZeroAngle, angle);

        public void DestroyOnTimer() => 
            StartCoroutine(DestroyOnTimerCoroutine());

        private IEnumerator DestroyOnTimerCoroutine()
        {
            yield return _waitBeforeDestroy;
            OnDead?.Invoke();
        }
    }
}