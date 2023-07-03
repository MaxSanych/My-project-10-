using UnityEngine;
using UnityEngine.Events;

public class Alarm : MonoBehaviour
{
    [SerializeField] private UnityEvent _faced;
    [SerializeField] private UnityEvent _notFaced;
    [SerializeField] private UnityEvent _soundHasDecreased;

    public bool IsFaced { get; private set; }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent<Thief>(out Thief thief))
        {
            IsFaced = true;
            _faced.Invoke();
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.TryGetComponent<Thief>(out Thief thief))
        {
            IsFaced = false;
            _notFaced.Invoke();
        }
    }

    public void TurnOffSound()
    {
        _soundHasDecreased.Invoke();
    }
}
