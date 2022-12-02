using System.Collections;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField]
    private AudioClip _collictionSound;
    private SoundPlayer _soundPlayer;
    private bool _isCollected;

    private CoinsBank _bank;

    public void Initialize(CoinsBank bank, SoundPlayer soundPlayer)
    {
        _bank = bank;
        _soundPlayer = soundPlayer;
    }


    private void OnTriggerEnter(Collider other)
    {   
        if(_isCollected)
        {
            return;
        }

        if(other.TryGetComponent(out Runner runner))
        {
            _soundPlayer.PlayClip(_collictionSound);
            _isCollected = true;
            _bank.AddCoin();
            Destroy(gameObject, 0.2f);
        }
    }
}
