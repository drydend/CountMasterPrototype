using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class MultipleGate : MonoBehaviour
{
    [SerializeField]
    private List<Gate> _gates = new List<Gate>();

    private void Awake()
    {
        foreach(var gate in _gates)
        {
            gate.OnActivated += DisableGates;
        }
    }

    private void DisableGates()
    {
        foreach (var gate in _gates)
        {
            gate.Disable();
        }
    }
}
