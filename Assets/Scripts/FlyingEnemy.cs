using TMPro;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    protected Rigidbody rb;
    [SerializeField] protected float speed;

    protected Vector3 targetPosition;

    private void Awake()
    {
        targetPosition = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        SetDestination();
        Vector3 direction = (targetPosition - transform.position).normalized;
        transform.up = direction;
        rb.linearVelocity = direction * speed;
    }

    protected virtual void SetDestination()
    {
    }
}
