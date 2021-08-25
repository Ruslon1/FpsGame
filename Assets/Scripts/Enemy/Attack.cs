using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private Enemy _enemy;
    [SerializeField] private Player _player;

    private void Start()
    {
        _enemy = GetComponent<Enemy>();
    }

    private void Update()
    {
        if (Vector3.Distance(_player.transform.position, _enemy.transform.position) <= 15)
        {
            _enemy.SetBehaviorShoot();
        }
    }
}