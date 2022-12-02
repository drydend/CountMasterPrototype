using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.TextCore.Text;
using UnityEngine;

public class RunnerRuningToDesiredPositionState : BaseState
{
    private const string RunningAnimationBoolName = "Runing";

    private Runner _runner;
    private StateMachine _stateMachine;
    private Timer _lastDeathTimer;
    private Animator _animator;

    public RunnerRuningToDesiredPositionState(Runner runner, StateMachine stateMachine,
        Timer lestDeasthTimer ,Animator animator)
    {
        _runner = runner;
        _stateMachine = stateMachine;
        _animator = animator;
        _lastDeathTimer = lestDeasthTimer;
    }

    public override void Enter()
    {
        _lastDeathTimer.OnReseted += StopRuningToDesiredPosition;
        _runner.StartMovingToDesiredPosition();
        _animator.SetBool(RunningAnimationBoolName, true);
    }

    public override void Exit()
    {
        _lastDeathTimer.OnReseted -= StopRuningToDesiredPosition;
        _runner.StopMovingToDesiredPosition();
        _animator.SetBool(RunningAnimationBoolName, false);
    }

    private void StopRuningToDesiredPosition()
    {
        _stateMachine.SwitchState<RunnerRunningState>();

    }
}
