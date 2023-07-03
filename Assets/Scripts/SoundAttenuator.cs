using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class SoundAttenuator : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    [SerializeField] private float _minVolume;
    [SerializeField] private float _maxVolume;

    [SerializeField] private UnityEvent _alarmWentOff;

    private float _volumeChangeRate = 0.001f;
    private float _muteTrigger = 0.001f;

    public void EnableVolumeDown()
    {
        var alarm = GetComponent<Alarm>();
        _alarmWentOff.Invoke();
        StartCoroutine(TurnDownVolume(_audioSource.volume, alarm));
    }

    private IEnumerator TurnDownVolume(float volume, Alarm alarm)
    {
        for (float i = 0; i < volume; i += _volumeChangeRate)
        {
            _audioSource.volume = Mathf.MoveTowards(volume, _minVolume, i);

            yield return null;

            if (_audioSource.volume < _muteTrigger)
            {
                alarm.TurnOffSound();
                break;
            }
            else if(alarm.IsFaced == true)
            {
                break;
            }
        }
    }
}
