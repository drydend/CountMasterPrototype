using System;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgressBar : MonoBehaviour
{
    [SerializeField]
    private Slider _slider;
    [SerializeField]
    private Transform _startPosition;
    [SerializeField]
    private Transform _endPosition;
    [SerializeField]
    private Transform _playerPosition;

    private void Update()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        var value = Mathf.InverseLerp(_startPosition.position.z, _endPosition.position.z, _playerPosition.position.z);
        _slider.value = value;
    }
}
