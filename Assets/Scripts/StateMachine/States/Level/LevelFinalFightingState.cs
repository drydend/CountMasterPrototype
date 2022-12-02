using System.Collections.Generic;
using UnityEngine;

public class LevelFinalFightingState : BaseState
{
    private PlayerCrowd _playerCrowd;
    private EnemyCrowd _enemyCrowd;
    private PlayerCrowdMover _playerMover;

    private StateMachine _machine;

    public LevelFinalFightingState(StateMachine stateMachine , EnemyCrowd enemyCrowd,PlayerCrowdMover crowdMover ,
        PlayerCrowd playerCrowd)
    {
        _machine = stateMachine;
        _enemyCrowd = enemyCrowd;
        _playerCrowd = playerCrowd;
        _playerMover = crowdMover;
    }

    public override void Enter()
    {
        _enemyCrowd.OnNumberOfCharactersChanged += CheckWinCondition;
        _playerMover.MovePlayerTo(_enemyCrowd.transform.position);
        _playerCrowd.StartFight(_enemyCrowd.transform);
    }

    public override void Exit()
    {
        _enemyCrowd.OnNumberOfCharactersChanged -= CheckWinCondition;
        _enemyCrowd.StopFight();
        _playerCrowd.StopFight();
    }

    private void CheckWinCondition()
    {
        if(_enemyCrowd.NumberOfCharacters == 0)
        {
            _machine.SwitchState<LevelWinState>();
        }
    }
}
