using UnityEngine;

public class AddingGates : Gate
{ 
    private void OnTriggerEnter(Collider other)
    {
        if (!_isActive)
        {
            return;
        }

        if(other.gameObject.TryGetComponent(out Runner runner))
        {
            _playerCrowd.AddRunners(_value);
            Activate();
        }
    }
}
