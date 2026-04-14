using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private HealthUI healthUI;
    [SerializeField] private PlayerArmor armor;
    
    private int _currentHealth;
    private int _remainingArmor;
    private bool _isDead;
    public int CurrentHealth => _currentHealth;
    
    void Awake()
    {
        _currentHealth = maxHealth;
    }
    
    public void TakeDamage(int damage)
    {
        if (_isDead) return;
            
        _remainingArmor = armor.TakeArmorDamage(damage);
        
       _currentHealth -= _remainingArmor;
       _currentHealth = Mathf.Clamp(_currentHealth, 0, maxHealth);
       
       healthUI.OnDamage();

       if (_currentHealth <= 0)
       {
           Death();
       }
    }

    public bool CanHeal()
    {
        return _currentHealth < maxHealth;
    }

    public void Heal(int heal)
    {
        _currentHealth += heal;
        _currentHealth = Mathf.Clamp(_currentHealth, 0, maxHealth);
        
        healthUI.OnDamage();
    }

    private void Death()
    {
        _isDead = true;
        Destroy(gameObject);
    }
    
}
