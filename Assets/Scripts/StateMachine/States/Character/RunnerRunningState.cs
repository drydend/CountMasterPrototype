using UnityEngine;

public class RunnerRunningState : BaseState
{
    private const string RunningAnimationBoolName = "Runing";

    private Animator _animator;
    private Timer _lastDeathTimer;
    private StateMachine _stateMachine;

    public RunnerRunningState(Animator animator,StateMachine stateMachine ,Timer lastDeathTimer)
    {
        _animator = animator;
        _stateMachine = stateMachine;
        _lastDeathTimer = lastDeathTimer;
    }

    public override void Enter()
    {
        _lastDeathTimer.OnFinished += StartRuningToDesiredPosition;
        _animator.SetBool(RunningAnimationBoolName, true);
    }

    public override void Exit()
    {
        _lastDeathTimer.OnFinished -= StartRuningToDesiredPosition;
    }

    private void StartRuningToDesiredPosition()
    {
        _stateMachine.SwitchState<RunnerRuningToDesiredPositionState>();
    }
}


