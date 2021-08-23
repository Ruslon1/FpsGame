using System;
using UnityEngine;

public class EnemyBehaviorFight : IEnemyBehavior
{
    private Animator _enemyAnimator;

    public void SetFields(Animator enemyAnimator)
    {
        _enemyAnimator = enemyAnimator;
    }
    
    public void Enter()
    {
        Debug.Log("Enter EnemyBehaviorFight");
        _enemyAnimator.SetTrigger("Hit");
    }

    public void Exit()
    {
        Debug.Log("Exit EnemyBehaviorFight");
    }

    public void Update()
    {
        Debug.Log("Update EnemyBehaviorFight");
    }
}