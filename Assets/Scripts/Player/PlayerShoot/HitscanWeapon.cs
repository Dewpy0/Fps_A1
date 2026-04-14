using UnityEngine;

public class HitscanWeapon : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    
    [SerializeField] private GameObject muzzleFlash;
    [SerializeField] private GameObject bloodEffect;
    [SerializeField] private GameObject bulletHole;
    
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip hitSound;
    
    [SerializeField] private CrosshairUI crosshairUI;
    [SerializeField] private PlayerAmmo playerAmmo;
    
    [SerializeField] private Animator shootAnim;
    
    [SerializeField] private float weaponRange;
    [SerializeField] private int damage;
    [SerializeField] private float timeMuzzleFlash;
    [SerializeField] private float fireRate;

    private bool _canShoot = true;

    public void TryShoot()
    {
        if (playerAmmo == null) return;
     
        if (!playerAmmo.HasAmmo()) return;
        
        if (!_canShoot) return;
        
        muzzleFlash.SetActive(true);
        Invoke("HideMuzzle", timeMuzzleFlash);
        
        audioSource.PlayOneShot(hitSound);
            
        crosshairUI.OnShoot();

        shootAnim.Play("Fire_Pistol", 0, 0f);
        
        _canShoot = false;
        Invoke("ResetShoot", fireRate);
        
        playerAmmo.UseAmmo();
        
        RaycastHit hit;
        
        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, weaponRange))
        {
            var target = hit.collider.GetComponent<IDamageable>();
            var normalHit = hit.point + hit.normal * 0.01f;
            
            if (target != null)
            {
                var effectBlood = Instantiate(bloodEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(effectBlood, 0.5f);
                target.TakeDamage(damage);
            }
            else
            {
                var hole = Instantiate(bulletHole,
                    normalHit,
                    Quaternion.LookRotation(hit.normal),
                    hit.collider.transform);
                Destroy(hole,10f);
            }
        }
    }

    private void ResetShoot()
    {
        _canShoot = true;
    }

    private void HideMuzzle()
    {
        muzzleFlash.SetActive(false);
    }
}
