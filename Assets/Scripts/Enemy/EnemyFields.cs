using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFields : MonoBehaviour
{
    [SerializeField] private Animator _enemyAnimator;
    [SerializeField] private List<Transform> _locationPoints;
    [SerializeField] private NavMeshAgent _agent;

    private void Awake()
    {
        new EnemyBehaviorPatrol().SetFields(_enemyAnimator, _agent, _locationPoints);
        new EnemyBehaviorFight().SetFields(_enemyAnimator);
        new EnemyBehaviorShoot().SetFields(_enemyAnimator);
    }
}