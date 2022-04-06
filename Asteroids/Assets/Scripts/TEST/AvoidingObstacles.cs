using Tags;
using UnityEngine;

namespace TEST
{
    public class AvoidingObstacles : MonoBehaviour
    {
        [SerializeField] private float _avoidingSpeed;
        [SerializeField] private float _viewRadius;
        [SerializeField, Range(3, 50)] private int _rayAmount = 3;
        [SerializeField] private float _rayRange;
        [Space] 
        [SerializeField] private MoveInDirection _moveInDirection;

        private void Update()
        {
            var halfOfViewRadius = _viewRadius / 2;
            var step = -_viewRadius / (_rayAmount - 1);
            var rejectCoefficient = 0;

            for (int i = 0; i < _rayAmount; i++)
            {
                var direction = Quaternion.Euler(0f, 0f, halfOfViewRadius + step * i) * _moveInDirection.MoveDirection;
                var hitInfo = Physics2D.Raycast(transform.position, direction, _rayRange);
                
                if (hitInfo && hitInfo.collider.gameObject.GetComponent<ObstacleTag>() != null)
                {
                    if (Vector3.SignedAngle(_moveInDirection.MoveDirection, direction, Vector3.back) >= 0)
                        rejectCoefficient += 3;
                    else
                        rejectCoefficient -= 2;
                }
            }

            if (rejectCoefficient != 0)
                _moveInDirection.RejectMoveDirection(rejectCoefficient, _avoidingSpeed);
            else
            {
                if (Vector3.SignedAngle(_moveInDirection.MoveDirection, _moveInDirection.TargetDirection,
                        Vector3.back) >= 0)
                {
                    if (Vector3.Angle(_moveInDirection.MoveDirection, _moveInDirection.TargetDirection) >= 1f)
                        _moveInDirection.RejectMoveDirection(-2, _avoidingSpeed * 2);
                }
                else
                {
                    if (Vector3.Angle(_moveInDirection.MoveDirection, _moveInDirection.TargetDirection) >= 1f)
                        _moveInDirection.RejectMoveDirection(2, _avoidingSpeed * 2);
                }
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, transform.position + _moveInDirection.MoveDirection.normalized);
            Gizmos.DrawWireSphere(transform.position + _moveInDirection.MoveDirection.normalized, 0.1f);
            Gizmos.color = Color.white;

            var halfOfViewRadius = _viewRadius / 2;
            var step = -_viewRadius / (_rayAmount - 1);

            for (int i = 0; i < _rayAmount; i++)
            {
                var ray = Quaternion.Euler(0f, 0f, halfOfViewRadius + step * i) * _moveInDirection.MoveDirection;
                Gizmos.DrawLine(transform.position, transform.position + ray.normalized);
                Gizmos.DrawWireSphere(transform.position + ray.normalized, 0.1f);
            }
        }
    }
}