using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerCrowd : Crowd, IEnumerable<Runner>
{   
    public static PlayerCrowd Current { get; private set; }

    [SerializeField]
    private SoundPlayer _soundPlayer;
    [SerializeField]
    private int _startNumberOfRunners;
    [SerializeField]
    private Runner _runnerPrefab;
    [SerializeField]
    private float _timeToMoveAfterDeath = 0.7f;
    private Timer _lastDeathTimer;

    private List<Runner> _runners = new List<Runner>();
    private Type _currentRunnersState;

    public void Initialize()
    {   
        Current = this;
        _lastDeathTimer = new Timer(_timeToMoveAfterDeath);
        _lastDeathTimer.OnFinished += StartMoving;
        _lastDeathTimer.Pause();
    }

    public void AddRunners(int numberOfRunners)
    {   
        if(numberOfRunners < 0)
        {
            throw new Exception("Number of runners to add must be more than zero");
        }

        for (int i = 0; i < numberOfRunners; i++)
        {
            AddRunner();
        }
    }

    public void RemoveRunners(int numberOfRunners)
    {
        for (int i = 0; i < numberOfRunners && _runners.Count > 0; i++)
        {
            var runner = _runners.First();
            runner.StateMachine.ExitCurrentState();
            _runners.Remove(runner);
            Destroy(runner.gameObject);
            NumberOfCharacters--;
        }
    }

    public Runner AddRunner()
    {
        var runner = Instantiate(_runnerPrefab, transform);
        runner.transform.position = GetRandomPosition();
        runner.Initialize(transform, _lastDeathTimer, _soundPlayer);
        runner.StateMachine.SwitchState(_currentRunnersState);

        _runners.Add(runner);
        runner.OnDied += RemoveRunner;
        runner.OnDied += (Runner) => _lastDeathTimer.ResetTimer();
        NumberOfCharacters++;

        return runner;
    }

    public void RemoveRunner(Runner runner)
    {
        _runners.Remove(runner);
        runner.StateMachine.ExitCurrentState();
        NumberOfCharacters--;
    }

    public void StartFight(Transform fightPosition)
    {   
        foreach (var runner in _runners)
        {
            runner.SetDesiredPosition(fightPosition);
            runner.StateMachine.SwitchState<CharacterFightState>();
        }

        _currentRunnersState = typeof(CharacterFightState);
    }

    public void StopFight()
    {
        foreach (var runner in _runners)
        {
            runner.SetDesiredPosition(transform);
        }
    }

    public void StartMoving()
    {
        foreach (var runner in _runners)
        {
            runner.StateMachine.SwitchState<RunnerRuningToDesiredPositionState>();
        }

        _currentRunnersState = typeof(RunnerRuningToDesiredPositionState);
    }

    public void StopMoving()
    {
        foreach (var runner in _runners)
        {
            runner.StateMachine.SwitchState<CharacterIdleState>();
        }
        _currentRunnersState = typeof(CharacterIdleState);
    }

    public IEnumerator<Runner> GetEnumerator()
    {
        return _runners.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private Vector3 GetRandomPosition()
    {
        Vector3 delta = UnityEngine.Random.insideUnitSphere * 0.5f;
        delta.y = 0;
        Vector3 newPosition = transform.position + delta;
        return newPosition;
    }


    private void Awake()
    {
        _lastDeathTimer = new Timer(_timeToMoveAfterDeath);
        _currentRunnersState = typeof(CharacterIdleState);

        AddRunners(_startNumberOfRunners);
    }

    private void Update()
    {
        _lastDeathTimer.UpdateTick(Time.deltaTime);
    }
}
