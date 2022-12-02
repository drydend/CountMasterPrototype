using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GatesValueText : MonoBehaviour
{
    private static Dictionary<Type, string> _gatesSign = new Dictionary<Type, string>()
    {
        { typeof(AddingGates) , "+" },
        { typeof(SubstractingGates) , "-" },
        { typeof(MultiplyingGates) , "*" },
        { typeof(DividingGates) , "/" }
    };

    [SerializeField]
    private TMP_Text _text;
    [SerializeField]
    private Gate _gates;

    private void Start()
    {
        _text.text = _gatesSign[_gates.GetType()] + _gates.Value.ToString();
    }
}
