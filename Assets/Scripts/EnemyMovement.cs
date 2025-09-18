using System.Collections;
using UnityEngine;

public class EnemyMovement : Movement
{
    [SerializeField] private Vector3 direction;
    [SerializeField] private float changeDirectionCooldown;

    private IEnumerator ChangeDirection()
    {
        while(true)
        {
            direction *= -1;
            direction.Normalize();
            yield return new WaitForSeconds(changeDirectionCooldown);
        }
    }

    protected override void Init()
    {
        base.Init();
        StartCoroutine(ChangeDirection());
    }

    protected override void Move()
    {
        rb.linearVelocity = new Vector3(direction.x * movementSpeed, rb.linearVelocity.y, direction.z * movementSpeed);
    }
}
