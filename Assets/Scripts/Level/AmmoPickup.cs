using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] private int pickupAmmo;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           var amun = other.GetComponent<PlayerAmmo>();
           if (amun != null)
           {
               amun.AddAmmo(pickupAmmo);
               Destroy(gameObject);
           }
        }
    }
}
