using UnityEngine;

public class FlyingEnemyRandom : FlyingEnemy
{
    [SerializeField] private float randomIntervalPosition;
    protected override void SetDestination()
    {
        if (Vector3.Distance(transform.position, targetPosition) < 1f)
        {
            targetPosition = new Vector3(
                Random.Range(-randomIntervalPosition, randomIntervalPosition),
                transform.position.y,
                Random.Range(-randomIntervalPosition, randomIntervalPosition));
        }
    }
}
