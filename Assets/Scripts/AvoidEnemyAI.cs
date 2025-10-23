using UnityEngine;

public class AvoidEnemyAI : BaseEnemyAI
{
    [SerializeField] private float detectionRange;

    protected override void SetDestination()
    {
        if (target != null)
        {
            if (Vector3.Distance(transform.position, target.position) <= detectionRange)
            {
                Vector3 direction = target.position - transform.position;
                direction.Normalize();
                direction *= -1;
                targetPosition = target.position + direction * detectionRange;
            }

        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);

    }
}
