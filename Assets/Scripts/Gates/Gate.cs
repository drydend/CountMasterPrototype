using System;
using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField]
    protected int _value;
    protected PlayerCrowd _playerCrowd;
    protected bool _isActive = true;

    [SerializeField]
    private GameObject _gate;
    
    public int Value => _value;

    public event Action OnActivated;

    public void Start()
    {
        _playerCrowd = PlayerCrowd.Current;
    }

    public void Disable()
    {
        _isActive = false;
    }

    protected void Activate()
    {
        OnActivated?.Invoke();
        Disable();
        _gate.SetActive(true);
    }
}
