using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCrowd : Crowd
{
    [SerializeField]
    private Enemy _enemyPrefab;
    [SerializeField]
    private int _startNumberOfEnemies = 1;
    private PlayerCrowd _playerCrowd;

    private bool _isInFight;

    private List<Enemy> _enemies = new List<Enemy>();

    public event Action OnFightStarted;
    public void Initialize(PlayerCrowd playerCrowd)
    {
        _playerCrowd = playerCrowd;
        for(int i = 0; i < _startNumberOfEnemies; i++)
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        var enemy = Instantiate(_enemyPrefab, transform);
        enemy.transform.position = GetRandomPosition();
        enemy.Initialize(_playerCrowd.transform);
        enemy.StateMachine.SwitchState<CharacterIdleState>();

        _enemies.Add(enemy);
        enemy.OnDied += RemoveEnemy;
        NumberOfCharacters++;
    }

    public void SetFightPosition(Transform position)
    {  
        foreach (var enemy in _enemies)
        {
            enemy.SetDesiredPosition(position);
        }
    }

    public void StopFight()
    {
        foreach (var enemy in _enemies)
        {
            enemy.StateMachine.SwitchState<CharacterIdleState>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Runner runner))
        {
            StartFight();
        }
    }

    private void StartFight()
    {
        if (_isInFight)
        {
            return;
        }

        _isInFight = true;
        OnFightStarted?.Invoke();
        foreach (var enemy in _enemies )
        {
            enemy.StateMachine.SwitchState<EnemyFightState>();
        }
    }

    private void RemoveEnemy(Enemy enemy)
    {
        _enemies.Remove(enemy);
        NumberOfCharacters--;
    }

    private Vector3 GetRandomPosition()
    {
        Vector3 delta = UnityEngine.Random.insideUnitSphere * 0.1f;
        delta.y = 0;
        Vector3 newPosition = transform.position + delta;
        return newPosition;
    }
}
