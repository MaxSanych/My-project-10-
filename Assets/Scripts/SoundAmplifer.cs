using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Alarm))]
[RequireComponent (typeof(AudioSource))]
public class SoundAmplifer : MonoBehaviour
{
    private AudioSource _audioSource;
    private Alarm _alarm;

    private float _maxVolume =1;
    private float _volumeChangeRate = 0.001f;

    private void Awake()
    {
        _alarm = GetComponent<Alarm>();
        _audioSource = GetComponent<AudioSource>();
    }

    public void EnableVolumeUp()
    {
        _audioSource.Play();

        StartCoroutine(TurnUpVolume(_audioSource.volume));
    }

    private IEnumerator TurnUpVolume(float volume)
    {
        for (float i = 0; i < _maxVolume; i += _volumeChangeRate)
        {
            _audioSource.volume = Mathf.MoveTowards(volume, _maxVolume, i);

            yield return null;

            if (_alarm.IsFaced == false)
                break;
        }
    }
}
