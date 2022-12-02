using System;
using TMPro;
using UnityEngine;

public class CrowdCounter : MonoBehaviour
{
    [SerializeField]
    private Crowd _crowd;
    [SerializeField]
    private TMP_Text _text;
    [SerializeField]
    private GameObject _counter;

    private void Awake()
    {
        _crowd.OnNumberOfCharactersChanged += UpdateUI;
    }

    private void Start()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {   
        _text.text = _crowd.NumberOfCharacters.ToString();
        if(_crowd.NumberOfCharacters == 0)
        {
            _counter.SetActive(false);
        }
    }
}
