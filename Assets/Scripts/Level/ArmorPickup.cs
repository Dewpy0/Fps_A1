using UnityEngine;

public class ArmorPickup : MonoBehaviour
{
    [SerializeField] private int pickupArmor;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var armor = other.GetComponent<PlayerArmor>();

            if (armor != null)
            {
                if (armor.Armor < armor.MaxArmor)
                {
                    armor.AddArmor(pickupArmor);
                    Destroy(gameObject);
                }
            }
        }
    }
}
