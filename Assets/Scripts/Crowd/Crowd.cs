using System;
using UnityEngine;

public class Crowd : MonoBehaviour
{
    private int _numberOfCharacers;
    public int NumberOfCharacters { 
        get 
        { 
            return _numberOfCharacers; 
        }
        protected set
        { 
            _numberOfCharacers = value;
            OnNumberOfCharactersChanged?.Invoke();
        } 
    }

    public event Action OnNumberOfCharactersChanged;
}