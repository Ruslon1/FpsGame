using UnityEngine;

public class EnemyBehaviorShoot: IEnemyBehavior
{
    private Animator _enemyAnimator;

    public void SetFields(Animator enemyAnimator)
    {
        _enemyAnimator = enemyAnimator;
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
        Debug.Log("Update EnemyBehaviorShoot");
    }
}