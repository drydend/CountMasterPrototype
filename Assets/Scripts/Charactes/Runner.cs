using System;
using System.Collections.Generic;
using UnityEngine;

public class Runner : Character
{
    [SerializeField]
    private AudioClip _deathSound;

    private SoundPlayer _soundPlayer;
    private StateMachine _stateMachine;
    public bool IsDead { get; private set; }

    public event Action<Runner> OnDied;

    public StateMachine StateMachine => _stateMachine;
    public void Initialize(Transform desiredPosition, Timer lastRunnerDeathTimer, SoundPlayer soundPlayer)
    {
        base.Initialize(desiredPosition);
        _soundPlayer = soundPlayer;

        var states = new Dictionary<Type, BaseState>();
        _stateMachine = new StateMachine(states);

        states[typeof(CharacterIdleState)] = new CharacterIdleState(this, _animator);
        states[typeof(RunnerRunningState)] = new RunnerRunningState(_animator, _stateMachine,lastRunnerDeathTimer);
        states[typeof(RunnerRuningToDesiredPositionState)] = new RunnerRuningToDesiredPositionState(this,_stateMachine
            , lastRunnerDeathTimer,_animator);
        states[typeof(CharacterFightState)] = new CharacterFightState(this, _animator);
    }

    public void Die()
    {
        if (IsDead)
        {
            return;
        }

        _soundPlayer.PlayClip(_deathSound);
        IsDead = true;
        OnDied?.Invoke(this);
        Destroy(gameObject);
    }
}
