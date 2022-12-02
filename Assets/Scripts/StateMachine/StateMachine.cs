using System;
using System.Collections.Generic;

public class StateMachine
{
    private Dictionary<Type, BaseState> _states;
    private BaseState _currentState;
    public StateMachine(Dictionary<Type, BaseState> states)
    {
        _states = states;
    }
    public void SwitchState<T>() where T : BaseState
    {
        if (!_states.ContainsKey(typeof(T)))
        {
            throw new Exception($"Don`t have this type of state: {typeof(T)}");
        }

        _currentState?.Exit();
        _currentState = _states[typeof(T)];
        _currentState.Enter();
    }

    public void SwitchState(Type type)
    {
        if (!_states.ContainsKey(type))
        {
            throw new Exception($"Don`t have this type of state: {type}");
        }

        _currentState?.Exit();
        _currentState = _states[type];
        _currentState.Enter();
    }

    public void ExitCurrentState()
    {
        _currentState?.Exit();
        _currentState = null;
    }
}
