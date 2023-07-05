using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class SoundVolumeChanger : MonoBehaviour
{
    [SerializeField] private float _duration;

    private AudioSource _audioSource;

    private float _minVolume = 0;
    private float _maxVolume = 1;
    private float _muteTrigger = 0.001f;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (_audioSource.volume < _muteTrigger)
        {
            _audioSource.Stop();
        }
    }

    public void EnableVolumeUp()
    {
        _audioSource.Play();

        StartCoroutine(ChangeVolume(_audioSource.volume, _maxVolume));
    }

    public void EnableVolumeDown()
    {
        StartCoroutine(ChangeVolume(_audioSource.volume, _minVolume));
    }

    private IEnumerator ChangeVolume(float volume, float volumeTarget)
    {
        float time = 0;

        while (time < _duration)
        {
            time += Time.deltaTime;
            _audioSource.volume = Mathf.MoveTowards(volume, volumeTarget, time/_duration);

            yield return null;
        }
    }
}