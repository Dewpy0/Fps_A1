using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private int enemyMaxHealth;

    private int _currentHealth;
    private bool _isDead;

    private void Start()
    {
        _currentHealth = enemyMaxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (_isDead) return; 

        _currentHealth -= damage;

        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        _isDead = true;
        Destroy(gameObject);
    }
}