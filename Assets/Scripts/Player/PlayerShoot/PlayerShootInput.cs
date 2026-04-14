using UnityEngine;

public class PlayerShootInput : MonoBehaviour
{
    [SerializeField] private HitscanWeapon currentWeapon;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            currentWeapon.TryShoot();
        }
    }
}
