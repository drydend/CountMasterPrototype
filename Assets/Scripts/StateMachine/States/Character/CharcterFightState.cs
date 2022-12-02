using UnityEngine;

public class CharacterFightState : BaseState
{
    private const string FightAnimationBoolName = "Runing";

    private Character _character;
    private Animator _animator;

    public CharacterFightState(Character character, Animator animator)
    {
        _character = character;
        _animator = animator;
    }

    public override void Enter()
    {
        _character.StartMovingToDesiredPosition();
        _animator.SetBool(FightAnimationBoolName, true);
    }

    public override void Exit()
    {
        _character.StopMovingToDesiredPosition();
        _animator.SetBool(FightAnimationBoolName, false);
    }
}
