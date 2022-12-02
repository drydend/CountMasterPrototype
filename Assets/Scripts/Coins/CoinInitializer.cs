using System.Collections.Generic;
using UnityEngine;

public class CoinInitializer : MonoBehaviour
{
    [SerializeField]
    private SoundPlayer _soundPlayer;
    [SerializeField]
    private CoinsBank _bank;
    [SerializeField]
    private List<Coin> _coins;

    private void Awake()
    {
        foreach (var coin in _coins)
        {
            coin.Initialize(_bank, _soundPlayer);
        }
    }
}
