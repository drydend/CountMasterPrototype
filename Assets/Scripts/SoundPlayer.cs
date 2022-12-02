using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    [SerializeField]
    private AudioSource _audioSource;

    public void PlayClip(AudioClip audioClip)
    {
        _audioSource.PlayOneShot(audioClip);
    }
}
