using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float sensitivity;
    [SerializeField] private float smoothTime = 0.1f;
    
    private float _xRotation;
    private float _velocityX;
    private float _currentXRotation;
    
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        MouseInput();
    }
    
    private void MouseInput()
    {
        var xMouse = Input.GetAxis("Mouse X");
        var yMouse = Input.GetAxis("Mouse Y");
        
        xMouse *= sensitivity;
        yMouse *= sensitivity;
        
        transform.Rotate(0, xMouse, 0);
        
        _xRotation -= yMouse;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);
        
        _currentXRotation = Mathf.SmoothDamp(_currentXRotation,
            _xRotation,
            ref _velocityX,
            smoothTime);
        
        cameraTransform.localRotation = Quaternion.Euler(_currentXRotation, 0f, 0f);
    }
}
