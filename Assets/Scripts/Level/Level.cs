using Assets.Scripts;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Level
{
    private PlayerCrowdMover _crowdMover;
    private Transform _runingStateCameraPosition;
    private LevelStartPanel _levelStarter;
    private CameraFollower _camera;
    private EnemyCrowd _enemyCrowd;
    private PlayerCrowd _playerCrowd;
    private List<Security> _allSecurity;
    private GameOverScrene _gameOverScrene;
    private LevelWinScrene _levelWinScrene;
    private LevelUI _levelUI;

    private StateMachine _machine;

    public Level(PlayerCrowdMover crowdMover, Transform runingStateCameraPosition, EnemyCrowd enemyCrowd,
        PlayerCrowd playerCrowd,List<Security> allSecurity,LevelStartPanel levelStarter,
        CameraFollower cameraFollower, GameOverScrene gameOverScrene, LevelWinScrene levelWinScrene,  LevelUI levelUI)
    {
        _playerCrowd = playerCrowd;
        _enemyCrowd = enemyCrowd;
        _crowdMover = crowdMover;
        _runingStateCameraPosition = runingStateCameraPosition;
        _allSecurity = allSecurity;
        _levelStarter = levelStarter;
        _camera = cameraFollower;
        _gameOverScrene = gameOverScrene;
        _levelWinScrene = levelWinScrene;
        _levelUI = levelUI;
    }

    public void StartLevel()
    {
        PrepareLevel();
        _machine.SwitchState<LevelIdleState>();
    }

    private void PrepareLevel()
    {
        _enemyCrowd.OnFightStarted += OnFightStarted;
        _playerCrowd.OnNumberOfCharactersChanged += CheckLoseCondition;

        var states = new Dictionary<Type, BaseState>();
        _machine = new StateMachine(states);

        states[typeof(LevelIdleState)] = new LevelIdleState(this, _machine, _levelStarter);
        states[typeof(LevelRuningState)] = new LevelRuningState(_crowdMover, _allSecurity, _runingStateCameraPosition, _camera, _levelUI);
        states[typeof(LevelFinalFightingState)] = new LevelFinalFightingState(_machine, _enemyCrowd,_crowdMover ,_playerCrowd);
        states[typeof(LevelWinState)] = new LevelWinState(_levelWinScrene, _levelUI);
        states[typeof(LevelLoseState)] = new LevelLoseState(_gameOverScrene, _levelUI);
    }

    private void CheckLoseCondition()
    {
        if (_playerCrowd.NumberOfCharacters == 0)
        {
            _machine.SwitchState<LevelLoseState>();
        }
    }

    private void OnFightStarted()
    {
        _machine.SwitchState<LevelFinalFightingState>();
    }
}
