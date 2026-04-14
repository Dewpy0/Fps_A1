using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float stopDistance;
    [SerializeField] private float retreatDistance;
    [SerializeField] private float attackDistance;

    [SerializeField] private Transform target;

    private bool _isRetreating;
    private bool _isDetected;
    private bool _isAttacking;

    public bool IsInAttackRange => Vector3.Distance(transform.position, target.position) < attackDistance;
    public bool IsRetreating => _isRetreating;
    public bool IsDetected => _isDetected;
    public bool IsMoving => _isDetected && 
                            (_isRetreating || Vector3.Distance(transform.position, target.position) > stopDistance);

    private void Update()
    {
        MoveEnemy();
    }

    public void DetectPlayer()
    {
        _isDetected = true;
    }

    private void MoveEnemy()
    {
        if (!_isDetected || target == null)
        {
            return;
        }

        var distance = Vector3.Distance(transform.position, target.position);

        if (distance < retreatDistance)
        {
            _isRetreating = true;
        }

        if (distance > stopDistance)
        {
            _isRetreating = false;
        }

        if (distance > stopDistance)
        {
            var direction = target.position - transform.position;
            direction.y = 0;
            direction.Normalize();
            transform.position += direction * speed * Time.deltaTime;
        }
        else if (_isRetreating)
        {
            var direction = transform.position - target.position;
            direction.y = 0;
            direction.Normalize();
            transform.position += direction * speed * Time.deltaTime;
        }
    }
}