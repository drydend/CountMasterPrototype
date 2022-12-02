using Assets.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class LevelBootstrap : MonoBehaviour
{
    [SerializeField]
    private PlayerCrowd _playerCrowd;
    [SerializeField]
    private PlayerCrowdMover _crowdMover;
    [SerializeField]
    private LevelStartPanel _levelStarter;
    [SerializeField]
    private LevelWinScrene _levelWinScrene;
    [SerializeField]
    private GameOverScrene _gameOverScrene;
    [SerializeField]
    private LevelUI _levelUI;

    [SerializeField]
    private List<Security> _levelSecurity;

    [SerializeField]
    private EnemyCrowd _enemyCrowd;

    [SerializeField]
    private Transform _runingStateCameraPosition;
    [SerializeField]
    private Transform _startPosition;

    [SerializeField]
    private CameraFollower _cameraFollower;

    private Level _level;

    private void Awake()
    {
        _playerCrowd.Initialize();
        _enemyCrowd.Initialize(_playerCrowd);
        _playerCrowd.transform.position = _startPosition.position;

        foreach (var security in _levelSecurity)
        {
            security.Initialize(_playerCrowd.transform);
        }

        _level = new Level(_crowdMover,_runingStateCameraPosition,_enemyCrowd,_playerCrowd, _levelSecurity,
            _levelStarter, _cameraFollower, _gameOverScrene, _levelWinScrene, _levelUI);
    }

    private void Start()
    {
        _level.StartLevel();
    }
}
