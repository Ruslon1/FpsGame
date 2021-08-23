using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviorPatrol : IEnemyBehavior
{
    private NavMeshAgent _agent;
    private Animator _enemyAnimator;
    private List<Transform> _locationPoints;

    public void SetFields(Animator enemyAnimator, NavMeshAgent agent, List<Transform> locationPoints)
    {
        _agent = agent;
        Debug.Log(agent);
        _locationPoints = locationPoints;

        _enemyAnimator = enemyAnimator;
    }

    public void Enter()
    {
        Debug.Log("EnemyBehaviorPatrol enter");
        Debug.Log(_agent);
        _agent.Move(_locationPoints[0].position);
    }

    public void Exit()
    {
        Debug.Log("EnemyBehaviorPatrol exit");
    }

    public void Update()
    {
        Debug.Log(_agent);
        Debug.Log("EnemyBehaviorPatrol update");
    }
}