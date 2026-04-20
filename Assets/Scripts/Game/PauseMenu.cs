using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private PlayerCamera playerCamera;

    private bool _isPaused;

    private void Start()
    {
        Time.timeScale = 1;
        _isPaused = false;
        pauseMenu.SetActive(false);

        if (playerCamera == null)
        {
            playerCamera = GetComponent<PlayerCamera>();
        }

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_isPaused)
            {
                Continue();
            }
            else
            {
                Menu();
            }
        }
    }

    private void Menu()
    {
        pauseMenu.SetActive(true);
        _isPaused = true;

        Time.timeScale = 0;

        if (playerCamera != null)
        {
            playerCamera.enabled = false;
        }

        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    public void Continue()
    {
        pauseMenu.SetActive(false);
        _isPaused = false;

        Time.timeScale = 1;

        if (playerCamera != null)
        {
            playerCamera.enabled = true;
        }

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void ExitMenu()
    {
        Time.timeScale = 1;
        _isPaused = false;

        if (playerCamera != null)
        {
            playerCamera.enabled = true;
        }

        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;

        SceneManager.LoadScene(0);
    }
}