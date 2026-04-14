using System;
using UnityEngine;

public class PlayerArmor : MonoBehaviour
{
    [SerializeField] private int maxArmor;
    
    public event Action OnArmorChanged;
    
    private int _armor;
    public int Armor => _armor;
    public int MaxArmor => maxArmor;

    private void Awake()
    {
        _armor = maxArmor;
        OnArmorChanged?.Invoke();
    }

    public int TakeArmorDamage(int armorDamage)
    {
        if (armorDamage <= _armor)
        {
            _armor -= armorDamage;
            OnArmorChanged?.Invoke();
            return 0;
        }
        else
        {
            int remaining = armorDamage - _armor;
            _armor = 0;
            OnArmorChanged?.Invoke();
            return remaining;
        }
    }

    public void AddArmor(int amount)
    {
        _armor += amount;

        if (_armor > maxArmor)
        {
            _armor = maxArmor;
        }

        OnArmorChanged?.Invoke();
    }
}