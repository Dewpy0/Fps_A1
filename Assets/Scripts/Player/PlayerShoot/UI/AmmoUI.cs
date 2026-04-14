using TMPro;
using UnityEngine;

public class AmmoUI : MonoBehaviour
{
    [SerializeField] private TMP_Text ammoText;
    [SerializeField] private PlayerAmmo playerAmmo;

    void AmmoUIUpdate()
    {
        if (playerAmmo == null || ammoText == null)
        {
            return;
        }
        ammoText.text = playerAmmo.Ammo.ToString();
    }

    private void OnEnable()
    {
        if (playerAmmo == null || ammoText == null)
        {
            return;
        }
        playerAmmo.OnAmmoChanged += AmmoUIUpdate;
    }

    private void OnDisable()
    {
        if (playerAmmo == null || ammoText == null)
        {
            return;
        }
        playerAmmo.OnAmmoChanged -= AmmoUIUpdate;
    }
}
