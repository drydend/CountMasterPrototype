using UnityEngine;

public class CharacterIdleState : BaseState
{
    private const string IdleAnimationBoolName = "Idle";

    private Character _character;
    private Animator _animator;

    public CharacterIdleState(Character character, Animator animator)
    {
        _character = character;
        _animator = animator;
    }

    public override void Enter()
    {
        _animator.SetBool(IdleAnimationBoolName, true);
    }

    public override void Exit()
    {
        _animator.SetBool(IdleAnimationBoolName, false);
    }
}
