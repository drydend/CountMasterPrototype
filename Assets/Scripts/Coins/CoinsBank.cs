using System;
using UnityEngine;

public class CoinsBank : MonoBehaviour
{
    public int NumberOfCoins { get; private set; }

    public event Action OnNumberOfCoinsChanged;

    public void AddCoin()
    {
        NumberOfCoins++;
        OnNumberOfCoinsChanged?.Invoke();
        SaveService.Instance.SaveCoins(NumberOfCoins);
    }

    private void Awake()
    {
        NumberOfCoins = SaveService.Instance.GetCoins();
        OnNumberOfCoinsChanged?.Invoke();
    }
}
