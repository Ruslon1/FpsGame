using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyFields))]
public class Enemy : MonoBehaviour
{
    private Dictionary<Type, IEnemyBehavior> _behaviorsMap;
    private IEnemyBehavior _currentBehavior;
    [SerializeField] private EnemyFields _enemyFields;

    private void Awake()
    {
        InitBehaviors();
        SetBehaviorByDefault();
    }

    private void Update()
    {
        _currentBehavior?.Update();
    }

    private void InitBehaviors()
    {
        _behaviorsMap = new Dictionary<Type, IEnemyBehavior>();

        _behaviorsMap[typeof(EnemyBehaviorFight)] = new EnemyBehaviorFight();
        _behaviorsMap[typeof(EnemyBehaviorShoot)] = new EnemyBehaviorShoot(_enemyFields.EnemyAnimator,
            _enemyFields.Player, _enemyFields.Enemy, _enemyFields.Agent);
        _behaviorsMap[typeof(EnemyBehaviorPatrol)] = new EnemyBehaviorPatrol(_enemyFields.EnemyAnimator,
            _enemyFields.Agent, _enemyFields.LocationPoints);
    }

    private void SetBehavior(IEnemyBehavior behavior)
    {
        _currentBehavior?.Exit();

        _currentBehavior = behavior;
        _currentBehavior.Enter();
    }

    private void SetBehaviorByDefault()
    {
        SetBehaviorPatrol();
    }

    private IEnemyBehavior GetBehavior<T>() where T : IEnemyBehavior
    {
        var type = typeof(T);
        return _behaviorsMap[type];
    }

    public void SetBehaviorShoot()
    {
        var behavior = GetBehavior<EnemyBehaviorShoot>();
        SetBehavior(behavior);
    }

    public void SetBehaviorFight()
    {
        var behavior = GetBehavior<EnemyBehaviorFight>();
        SetBehavior(behavior);
    }

    public void SetBehaviorPatrol()
    {
        var behavior = GetBehavior<EnemyBehaviorPatrol>();
        SetBehavior(behavior);
    }
}