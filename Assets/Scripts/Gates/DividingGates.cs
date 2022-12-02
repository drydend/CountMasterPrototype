using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class DividingGates : Gate
{
    private void OnTriggerEnter(Collider other)
    {
        if (!_isActive)
        {
            return;
        }

        if (other.gameObject.TryGetComponent(out Runner runner))
        {
            var numberToRemove = _playerCrowd.NumberOfCharacters - _playerCrowd.NumberOfCharacters/ _value;
            _playerCrowd.RemoveRunners(numberToRemove);
            Activate();
        }
    }
}
