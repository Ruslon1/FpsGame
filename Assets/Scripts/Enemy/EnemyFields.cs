using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFields : MonoBehaviour
{
    [SerializeField] private Animator _enemyAnimator;
    [SerializeField] private List<Transform> _locationPoints;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Player _player;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private PlayerChecker _checker;
    
    public Animator EnemyAnimator => _enemyAnimator;
    public List<Transform> LocationPoints => _locationPoints;
    public NavMeshAgent Agent => _agent;
    public Player Player => _player;
    public Enemy Enemy=>_enemy;
    public PlayerChecker Checker => _checker;
}