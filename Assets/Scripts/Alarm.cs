using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(SoundVolumeChanger))]

public class Alarm : MonoBehaviour
{
    private AudioSource _audioSource;
    private SoundVolumeChanger _volumeChanger;

    private float _minVolume = 0;
    private float _maxVolume = 1;
    private float _muteTrigger = 0.001f;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _volumeChanger = GetComponent<SoundVolumeChanger>();
    }

    private void Update()
    {
        if (_audioSource.volume < _muteTrigger)
        {
            _audioSource.Stop();
        }
    }
    public void TurnOn(bool isFaced)
    {
        _audioSource.Play();

        if (isFaced == true)
            _volumeChanger.TurnOn(_minVolume, _maxVolume);
        else
            _volumeChanger.TurnOn(_maxVolume, _minVolume);
    }
}