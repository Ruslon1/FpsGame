using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviorShoot : IEnemyBehavior
{
    private Animator _enemyAnimator;
    private Player _player;
    private Enemy _enemy;
    private NavMeshAgent _agent;

    public EnemyBehaviorShoot(Animator enemyAnimator, Player player, Enemy enemy, NavMeshAgent agent)
    {
        _agent = agent;
        _enemyAnimator = enemyAnimator;
        _player = player;
        _enemy = enemy;
    }

    public void Enter()
    {
        _enemyAnimator.SetBool("Shoot", true);
        Debug.Log("Enter EnemyBehaviorShoot");
    }

    public void Exit()
    {
        _enemyAnimator.SetBool("Shoot", false);

        Debug.Log("Exit EnemyBehaviorShoot");
    }

    public void Update()
    {
        _agent.isStopped = true;
        _enemy.transform.LookAt(_player.transform);
        Debug.Log("Update EnemyBehaviorShoot");                 
    }
}