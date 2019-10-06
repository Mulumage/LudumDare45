using System.Collections.Generic;
using UnityEngine;

public class PatrolMovement : MonoBehaviour
{
    public float Speed = 5;

    [SerializeField] private List<Transform> _patrolPoints;
    private int _patrolIndex;

    private void Update()
    {
        if (_patrolPoints.Count <= 0)
            return;

        Movement();
        CheckPatrolPoint();
    }

    private void Movement()
    {
        transform.position = Vector2.MoveTowards(transform.position,
            _patrolPoints[_patrolIndex].position,
            Speed * Time.deltaTime);
    }

    private void CheckPatrolPoint()
    {
        if (Vector2.Distance(transform.position, _patrolPoints[_patrolIndex].position) > 0.1f)
            return;

        var nextPoint = _patrolIndex;
        nextPoint++;

        if (nextPoint >= _patrolPoints.Count)
            nextPoint = 0;

        _patrolIndex = nextPoint;
    }
}