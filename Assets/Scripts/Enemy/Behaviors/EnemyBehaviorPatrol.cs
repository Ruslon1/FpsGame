using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviorPatrol : IEnemyBehavior
{
    private Animator _enemyAnimator;
    private List<Transform> _locationPoints;
    private NavMeshAgent _navMeshAgent;
    private Vector3 _currentLocationPoint;

    public EnemyBehaviorPatrol(Animator enemyAnimator, NavMeshAgent agent, List<Transform> locationPoints)
    {
        _navMeshAgent = agent;


        _locationPoints = locationPoints;
        _enemyAnimator = enemyAnimator;
    }


    public void Enter()
    {
        Move();
        Debug.Log("EnemyBehaviorPatrol enter");
    }

    public void Exit()
    {
        _enemyAnimator.SetFloat("Speed", 0);
        Debug.Log("EnemyBehaviorPatrol exit");
    }

    public void Update()
    {
        TryMove();
        Debug.Log("EnemyBehaviorPatrol update");
    }

    #region Move

    private void TryMove()
    {
        if ((_navMeshAgent.pathEndPosition - _navMeshAgent.transform.position).magnitude == 0)
        {
            //  _enemyAnimator.transform.Rotate(new Vector3(0,180,0));
            Debug.Log("fuck");
            Move();
        }
    }

    private void Move()
    {
        _currentLocationPoint = _locationPoints[Random.Range(0, _locationPoints.Count)].position;
        Debug.Log("ffuck");
        _navMeshAgent.SetDestination(_currentLocationPoint);
        _enemyAnimator.SetFloat("Speed", 1f);
    }

    #endregion
}