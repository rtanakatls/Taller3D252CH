using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyPoints : FlyingEnemy
{
    [SerializeField] private List<Vector3> points;
    private int currentPointIndex;
    protected override void SetDestination()
    {
        if (Vector3.Distance(transform.position, targetPosition) < 1f)
        {
            currentPointIndex++;
            if(currentPointIndex>=points.Count)
            {
                currentPointIndex = 0;
            }
            targetPosition = points[currentPointIndex];
        }
    }
}
