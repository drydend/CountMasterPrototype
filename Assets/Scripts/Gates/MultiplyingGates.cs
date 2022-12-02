using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class MultiplyingGates : Gate
{
    private void OnTriggerEnter(Collider other)
    {
        if (!_isActive)
        {
            return;
        }

        if (other.gameObject.TryGetComponent(out Runner runner))
        {
            _playerCrowd.AddRunners(_playerCrowd.NumberOfCharacters * (_value - 1));
            Activate();
        }
    }
}
