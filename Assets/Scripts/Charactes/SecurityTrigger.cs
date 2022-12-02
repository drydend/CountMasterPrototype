using System;
using UnityEngine;

public class SecurityTrigger : MonoBehaviour
{
    private bool _hasTriggered;
    public event Action Triggered;

    private void OnTriggerEnter(Collider other)
    {
        if (_hasTriggered)
        {
            return;
        }

        if (other.TryGetComponent(out Runner runner))
        {
            Triggered?.Invoke();
            _hasTriggered = true;
        }
    }
}