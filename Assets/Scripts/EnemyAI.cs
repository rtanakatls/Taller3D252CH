using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : BaseEnemyAI
{
    [SerializeField] private float detectionRange;
    [SerializeField] private float stoppingDistance;
    [SerializeField] private LayerMask lookingLayer;


    protected override void SetDestination()
    {
        if (target != null)
        {
            if (Vector3.Distance(transform.position, target.position) <= detectionRange)
            {
                RaycastHit hit;
                Vector3 direction = target.position - transform.position;
                if (Physics.Raycast(
                    transform.position,
                    direction.normalized,
                    out hit,
                    detectionRange,
                    lookingLayer,
                    QueryTriggerInteraction.UseGlobal
                    ))
                {
                    if (hit.collider.gameObject.CompareTag("Player"))
                    {
                        targetPosition = target.position;
                    }
                }
            }

            if (Vector3.Distance(transform.position, targetPosition) <= stoppingDistance)
            {
                targetPosition = transform.position;
            }

        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, stoppingDistance);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);

        if (target != null)
        {
            Gizmos.color = Color.yellow;
            Vector3 direction = target.position - transform.position;
            Gizmos.DrawRay(transform.position, direction.normalized * detectionRange);
        }
    }
}
