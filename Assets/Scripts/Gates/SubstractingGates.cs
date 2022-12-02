using UnityEngine;

public class SubstractingGates : Gate
{
    private void OnTriggerEnter(Collider other)
    {
        if (!_isActive)
        {
            return;
        }

        if (other.gameObject.TryGetComponent(out Runner runner))
        {   
            _playerCrowd.RemoveRunners(_value);
            Activate();
        }
    }
}
