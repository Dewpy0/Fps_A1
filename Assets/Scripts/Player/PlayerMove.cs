using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed = 20f;
    [SerializeField] private Animator animCam;

    private bool _isMoving;
    private CharacterController _playerController;
    private Vector3 _direction;

    private void Start()
    {
        _playerController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Move();
        MoveAnim();
    }

    private void Move()
    {
        var hor = Input.GetAxisRaw("Horizontal");
        var ver = Input.GetAxisRaw("Vertical");

        _direction = transform.forward * ver + transform.right * hor;
        _direction.Normalize();

        _playerController.Move(_direction * speed * Time.deltaTime);
    }

    private void MoveAnim()
    {
        _isMoving = _direction.magnitude > 0.1f;
        animCam.SetBool("isMoving", _isMoving);
    }
}