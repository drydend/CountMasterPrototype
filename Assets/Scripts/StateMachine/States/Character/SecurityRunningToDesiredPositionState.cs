using UnityEngine;

public class SecurityRunningToDesiredPositionState : BaseState
{
    private const string RunningAnimationBoolName = "Runing";

    private Animator _animator;
    private Security _character;
    private Timer _timer;

    public SecurityRunningToDesiredPositionState(Security character, Animator animator, Timer timer)
    {
        _character = character;
        _animator = animator;
        _timer = timer;
    }

    public override void Enter()
    {
        _timer.ResetTimer();
        _timer.OnFinished += EndRunning;
        _character.StartMovingToDesiredPosition();
        _animator.SetBool(RunningAnimationBoolName, true);
    }

    public override void Exit()
    {
        _timer.OnFinished -= EndRunning;
        _character.StopMovingToDesiredPosition();
        _animator.SetBool(RunningAnimationBoolName, false);
    }

    private void EndRunning()
    {
        _character.SmoothStopMovingToDesiredPosition();
    }
}
