using System.Collections.Generic;
using UnityEngine;

namespace TEST
{
    public class ObjectPooler : MonoBehaviour
    {
        private readonly Vector3 _hidePosition = new Vector3(10000f, 10000f, 10000f);
        
        [SerializeField] private int _size;
        [SerializeField] private GameObject _objectPref;
        
        private Queue<GameObject> _pool;
        
        private void Awake()
        {
            _pool = new Queue<GameObject>(_size);
            
            for (var i = 0; i < _size; i++)
            {
                var obj = Instantiate(_objectPref, _hidePosition, Quaternion.identity);
                _pool.Enqueue(obj);
                obj.SetActive(false);
            }
        }

        public void Instantiate(Vector3 position, Quaternion rotation)
        {
            if (_pool.Count == 0)
                return;
            
            var obj = _pool.Dequeue();
            obj.SetActive(true);
            obj.transform.position = position;
            obj.transform.rotation = rotation;
        }

        public void Utilize(GameObject obj)
        {
            if (_pool.Contains(obj))
                return;
            
            obj.transform.position = _hidePosition;
            _pool.Enqueue(obj);
            obj.SetActive(false);
        }
    }
}
