using System.ComponentModel;
using UnityEngine;

public class CharacterRunningToDesiredPositionState : BaseState
{
    private const string RunningAnimationBoolName = "Runing";

    private Animator _animator;
    private Character _character;

    public CharacterRunningToDesiredPositionState(Character character, Animator animator)
    {
        _character = character;
        _animator = animator;
    }

    public override void Enter()
    {
        _character.StartMovingToDesiredPosition();
        _animator.SetBool(RunningAnimationBoolName, true);
    }

    public override void Exit()
    {
        _character.StopMovingToDesiredPosition();
        _animator.SetBool(RunningAnimationBoolName, false);
    }
}

