using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class BaseEnemyAI : MonoBehaviour
{

    protected NavMeshAgent agent;
    protected Vector3 targetPosition;
    [SerializeField] protected Transform target;

    private void Awake()
    {
        targetPosition = transform.position;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        SetDestination();
        agent.SetDestination(targetPosition);
    }

    protected virtual void SetDestination()
    {

    }
}
