using System;
using UnityEngine;

public class PlayerAmmo : MonoBehaviour
{
    [SerializeField] private int ammo;
    [SerializeField] private int maxAmmo;
    
    public Action OnAmmoChanged;
    
    public int Ammo => ammo;

    public void UseAmmo()
    {
        if (ammo > 0)
        {
            ammo--;
            OnAmmoChanged?.Invoke();
        }
    }

    public void AddAmmo(int amount)
    {
        ammo += amount;
        if (ammo > maxAmmo)
        {
            ammo = maxAmmo;
        }
        OnAmmoChanged?.Invoke();
    }

    public bool HasAmmo()
    {
        return ammo > 0;
    }
}
