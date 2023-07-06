using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class SoundVolumeChanger : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void TurnOn(float volume, float volumeTarget)
    {
        StartCoroutine(ChangeVolume(volume, volumeTarget));
    }

    private IEnumerator ChangeVolume(float volume, float volumeTarget)
    {
        float duration = 5;
        float time = 0;

        while (time < duration)
        {
            time += Time.deltaTime;
            _audioSource.volume = Mathf.MoveTowards(volume, volumeTarget, time / duration);

            yield return null;
        }
    }
}