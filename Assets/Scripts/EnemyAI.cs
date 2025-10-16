using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private Transform target;


    private void Awake()
    {
        
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if(target!=null)
        {
            agent.SetDestination(target.position);
        }
    }

}
