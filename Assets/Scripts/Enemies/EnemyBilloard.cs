using UnityEngine;

public class EnemyBillboard : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private EnemyMovement enemyMovement;
    
    private Animator _animator;

    private void Start()
    {
        enemyMovement = GetComponentInParent<EnemyMovement>();
        _animator = GetComponent<Animator>();

        if (Camera.main != null)
        {
            cameraTransform = Camera.main.transform;
        }
    }

    private void LateUpdate()
    {
        if (cameraTransform == null)
        {
            return;
        }

        var state = _animator.GetCurrentAnimatorStateInfo(0);

        var target = cameraTransform.position;
        target.y = transform.position.y;
        transform.LookAt(target);

        if (!enemyMovement.IsMoving)
        {
            if (!state.IsName("Enemy_Idle"))
            {
                _animator.Play("Enemy_Idle");
            }

            return;
        }

        if (enemyMovement.IsRetreating)
        {
            if (!state.IsName("Enemy_BackWalk"))
            {
                _animator.Play("Enemy_BackWalk");
            }
        }
        else
        {
            if (!state.IsName("Enemy_Walk_Front"))
            {
                _animator.Play("Enemy_Walk_Front");
            }
        }
    }
}