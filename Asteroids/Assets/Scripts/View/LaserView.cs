using System.Collections;
using UnityEngine;

namespace View
{
    public class LaserView : MonoBehaviour
    {
        private readonly WaitForSeconds _waitBeforeDestroyObject = new WaitForSeconds(0.25f);
        
        private void Start() => 
            StartCoroutine(DestroyCoroutine());

        private void OnTriggerEnter2D(Collider2D col)
        {
            var enemy = col.GetComponent<EnemyTag>();

            if (enemy != null)
                Destroy(enemy.gameObject);
        }

        private IEnumerator DestroyCoroutine()
        {
            yield return _waitBeforeDestroyObject;
            Destroy(gameObject);
        }
    }
}