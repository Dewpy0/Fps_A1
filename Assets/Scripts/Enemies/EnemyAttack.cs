using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private float attackCooldown;

    [SerializeField] private EnemyMovement enemyMovement;
    private PlayerHealth _playerHealth;

    private float _timerAttack;

    private void Start()
    {
        _playerHealth = FindAnyObjectByType<PlayerHealth>();
        enemyMovement = GetComponent<EnemyMovement>();
    }

    private void Update()
    {
        _timerAttack -= Time.deltaTime;
        Attack();
    }

    private void Attack()
    {
        if(_playerHealth == null) return;
        
        if (enemyMovement.IsInAttackRange && _timerAttack <= 0)
        {
            _timerAttack = attackCooldown;
            _playerHealth.TakeDamage(damage);
        }
    }
}
