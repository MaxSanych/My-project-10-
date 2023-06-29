using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Alarm : MonoBehaviour
{
    [SerializeField] private UnityEvent _worked;

    [SerializeField] private AudioSource _audioSource;

    [SerializeField] private float _minVolume;
    [SerializeField] private float _maxVolume;

    private bool _isFaced;

    private float _volumeChangeRate = 0.001f;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent<Thief>(out Thief thief))
        {
            _isFaced = true;

            _worked?.Invoke();

            StartCoroutine(TurnUpVolume(_audioSource.volume));
        }

    }

    private void OnTriggerExit(Collider collision)
    {
        _isFaced = false;

        StartCoroutine(TurnDownVolume(_audioSource.volume));
    }

    private IEnumerator TurnUpVolume(float volume)
    {
        for (float i = 0; i < _maxVolume; i += _volumeChangeRate)
        {
            _audioSource.volume = Mathf.MoveTowards(volume, _maxVolume, i);

            yield return null;

            if (_isFaced == false)
                break;
        }
    }

    private IEnumerator TurnDownVolume(float volume)
    {
        for (float i = 0; i < volume; i += _volumeChangeRate)
        {
            _audioSource.volume = Mathf.MoveTowards(volume, _minVolume, i);

            yield return null;

            if (_isFaced == true)
                break;
        }
    }
}
