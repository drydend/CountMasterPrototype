using System.Collections.Generic;
using System;
using UnityEngine;

public class Enemy : Character
{
    [SerializeField]
    private GameObject _model;
    private StateMachine _stateMachine;
    private bool _isDead;

    public event Action<Enemy> OnDied;

    public StateMachine StateMachine => _stateMachine;
    public override void Initialize(Transform desiredPosition)
    {
        base.Initialize(desiredPosition);

        var states = new Dictionary<Type, BaseState>();
        _stateMachine = new StateMachine(states);

        states[typeof(EnemyFightState)] = new EnemyFightState(this, _animator);
        states[typeof(CharacterIdleState)] = new CharacterIdleState(this, _animator);
    }

    public void Die()
    {   
        OnDied?.Invoke(this);
        Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (_isDead)
        {
            return;
        }

        if (collision.gameObject.TryGetComponent(out Runner runner))
        {
            if (runner.IsDead)
            {
                return;
            }

            runner.Die();
            Die();
            _isDead = true;
        }
    }
}
