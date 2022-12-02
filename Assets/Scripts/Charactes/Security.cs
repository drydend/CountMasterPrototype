using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Security : Character
{
    [SerializeField]
    private float _acceleration = 1;
    [SerializeField]
    private float _stopingAcceleration = 2;
    [SerializeField]
    private float _followTime = 5f;
    [SerializeField]
    private GameObject _model;
    [SerializeField]
    private SecurityTrigger _securityTrigger;

    private float _currentSpeed;
    private StateMachine _stateMachine;
    private Timer _followTimer;

    private Coroutine _movingCoroutine;

    public override void Initialize(Transform desiredPosition)
    {
        base.Initialize(desiredPosition);

        _followTimer = new Timer(_followTime);
        var states = new Dictionary<Type, BaseState>();
        _stateMachine = new StateMachine(states);

        states[typeof(CharacterIdleState)] = new CharacterIdleState(this, _animator);
        states[typeof(SecurityRunningToDesiredPositionState)] = new SecurityRunningToDesiredPositionState(this, _animator, _followTimer);

        _stateMachine.SwitchState<CharacterIdleState>();
        _securityTrigger.Triggered += StartFollowing;
    }

    protected override IEnumerator MoveTowardsDesiredPosition()
    {
        while (true)
        {
            var newPosition = Vector3.MoveTowards(transform.position, _desiredPosition.position,
                _currentSpeed * Time.fixedDeltaTime);
            transform.position = newPosition;
            _model.transform.LookAt(_desiredPosition);

            _currentSpeed = Mathf.Clamp(_currentSpeed + _acceleration * Time.fixedDeltaTime, 0, _movementSpeed);
            yield return new WaitForFixedUpdate();
        }
    }

    public void StopFollowingImmidiatly()
    {
        _stateMachine.SwitchState<CharacterIdleState>();
    }

    public void SmoothStopMovingToDesiredPosition()
    {
        base.StopMovingToDesiredPosition();
        _movingCoroutine = StartCoroutine(SmoothStop());
    }

    private IEnumerator SmoothStop()
    {
        while(_currentSpeed > 0)
        {
            var newPosition = Vector3.MoveTowards(transform.position, _desiredPosition.position,
                _currentSpeed * Time.fixedDeltaTime);
            transform.position = newPosition;
            _model.transform.LookAt(_desiredPosition);

            _currentSpeed = Mathf.Clamp(_currentSpeed - _stopingAcceleration * Time.fixedDeltaTime , 0, _movementSpeed);
            yield return new WaitForFixedUpdate();
        }

        _stateMachine.SwitchState<CharacterIdleState>();
    }

    private void StartFollowing()
    {
        _stateMachine.SwitchState<SecurityRunningToDesiredPositionState>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Runner runner))
        {
            runner.Die();
        }
    }

    private void Update()
    {
        _followTimer.UpdateTick(Time.deltaTime);
    }
}

