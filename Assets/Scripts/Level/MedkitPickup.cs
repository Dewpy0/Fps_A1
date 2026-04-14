using System;
using UnityEngine;

public class MedkitPickup : MonoBehaviour
{
    [SerializeField] private int healAmount;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                if (!playerHealth.CanHeal())
                {
                    return;
                }
                playerHealth.Heal(healAmount);
                Destroy(gameObject);
            }
        }
    }
}
