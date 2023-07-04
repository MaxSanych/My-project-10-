using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Alarm))]
[RequireComponent(typeof(AudioSource))]
public class SoundAttenuator : MonoBehaviour
{
    private AudioSource _audioSource;
    private Alarm _alarm;

    private float _minVolume = 0;
    private float _volumeChangeRate = 0.001f;
    private float _muteTrigger = 0.001f;

    private void Awake()
    {
        _alarm = GetComponent<Alarm>();
        _audioSource = GetComponent<AudioSource>();
    }

    public void EnableVolumeDown()
    {
        _audioSource.Play();
        StartCoroutine(TurnDownVolume(_audioSource.volume));
    }

    private IEnumerator TurnDownVolume(float volume)
    {
        for (float i = 0; i < volume; i += _volumeChangeRate)
        {
            _audioSource.volume = Mathf.MoveTowards(volume, _minVolume, i);

            yield return null;

            if (_audioSource.volume <= _muteTrigger)
            {
                _audioSource.Stop();
                break;
            }
            else if (_alarm.IsFaced == true)
            {
                break;
            }
        }
    }
}
