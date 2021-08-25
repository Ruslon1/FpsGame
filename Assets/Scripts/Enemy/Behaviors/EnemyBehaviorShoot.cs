using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviorShoot : IEnemyBehavior
{
    private Animator _enemyAnimator;
    private Player _player;
    private Enemy _enemy;
    private NavMeshAgent _agent;
    private Vector3 _lastPlayerPosition;
    private PlayerChecker _playerChecker;

    public EnemyBehaviorShoot(Animator enemyAnimator, Player player, Enemy enemy, NavMeshAgent agent,
        PlayerChecker checker)
    {
        _agent = agent;
        _enemyAnimator = enemyAnimator;
        _player = player;
        _enemy = enemy;
        _playerChecker = checker;
    }

    public void Enter()
    {
        _agent.isStopped = true;
        _playerChecker.enabled = false;


        _enemyAnimator.SetBool("Shoot", true);
        Debug.Log("Enter EnemyBehaviorShoot");
    }

    public void Exit()
    {
        _enemyAnimator.SetBool("Shoot", false);
        _playerChecker.enabled = false;

        Debug.Log("Exit EnemyBehaviorShoot");
    }

    public void Update()
    {
        CheckPlayer();
        Debug.Log("Update EnemyBehaviorShoot");
    }

    private void TryStrike()
    {
        if (_player.Health <= 0)
            return;
        var chance = Random.Range(0, 100);
        if (chance <= 50)
        {
            _player.TakeDamage(Random.Range(20, 80));
        }
    }

    private void MoveToLastPlayerPosition(Vector3 lastPlayerPosition)
    {
        _agent.isStopped = false;
        _agent.SetDestination(lastPlayerPosition);
    }

    private void CheckPlayer()
    {
        Ray rayCast = new Ray(_enemy.transform.position, _player.transform.position - _enemy.transform.position);
        RaycastHit hit;


        if (Physics.Raycast(rayCast, out hit))
        {
            if (hit.collider.gameObject == _player.gameObject)
            {
                _lastPlayerPosition = hit.point;
                _enemy.transform.LookAt(_player.transform);
                TryStrike();
            }


            if (hit.collider.gameObject != _player.gameObject)
            {
                MoveToLastPlayerPosition(_lastPlayerPosition);
            }
        }
    }
}