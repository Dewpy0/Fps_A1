using UnityEngine;

public class DetectionZone : MonoBehaviour
{
    [SerializeField] private EnemyMovement enemyMovement;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }

        enemyMovement.DetectPlayer();
    }
}