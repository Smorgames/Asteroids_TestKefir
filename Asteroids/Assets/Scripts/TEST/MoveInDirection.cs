using UnityEngine;

namespace TEST
{
    public class MoveInDirection : MonoBehaviour
    {
        public Vector3 MoveDirection => _moveDirection;
        public Vector3 TargetDirection => _targetDirection;

        [SerializeField] private Vector3 _moveDirection;
        [SerializeField] private float _speed;

        private Vector3 _targetDirection;

        private void Awake() => 
            _targetDirection = _moveDirection;

        private void Update()
        {
            transform.position += _moveDirection.normalized * _speed * Time.deltaTime;
            var angle = _moveDirection.x > 0 
                ? -Vector3.Angle(Vector3.up, _moveDirection) 
                : Vector3.Angle(Vector3.up, _moveDirection);
            
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }

        public void RejectMoveDirection(int coefficient, float angle) =>
            _moveDirection = Quaternion.Euler(0f, 0f, coefficient * angle * Time.deltaTime) * _moveDirection;
    }
}
