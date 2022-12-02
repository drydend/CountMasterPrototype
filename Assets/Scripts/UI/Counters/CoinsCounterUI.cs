using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class CoinsCounterUI : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _text;
    [SerializeField]
    private CoinsBank _coinsBank;

    private void Awake()
    {
        _coinsBank.OnNumberOfCoinsChanged += UpdateUi;
    }

    private void Start()
    {
        UpdateUi();
    }

    private void UpdateUi()
    {
        _text.text = _coinsBank.NumberOfCoins.ToString();
    }
}

