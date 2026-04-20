using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DieButton : MonoBehaviour
{
    [SerializeField] private GameObject deathScreen;
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private PlayerCamera playerCamera;

    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }

    public void ScreenDeath()
    {
        playerHealth.Death();
        Time.timeScale = 1;

        if (playerCamera != null)
        {
            playerCamera.enabled = true;
        }
        
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        
        SceneManager.LoadScene("0");
    }
}
