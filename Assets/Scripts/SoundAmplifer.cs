using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class SoundAmplifer : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    [SerializeField] private float _minVolume;
    [SerializeField] private float _maxVolume;

    [SerializeField] private UnityEvent _alarmTurnedOn;

    private float _volumeChangeRate = 0.001f;

    public void EnableVolumeUp()
    {
        var alarm = GetComponent<Alarm>();
        _alarmTurnedOn.Invoke();

        StartCoroutine(TurnUpVolume(_audioSource.volume, alarm));
    }

    private IEnumerator TurnUpVolume(float volume, Alarm alarm)
    {
        for (float i = 0; i < _maxVolume; i += _volumeChangeRate)
        {
            _audioSource.volume = Mathf.MoveTowards(volume, _maxVolume, i);

            yield return null;

            if (alarm.IsFaced == false)
                break;
        }
    }
}
