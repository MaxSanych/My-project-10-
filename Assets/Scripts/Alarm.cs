using UnityEngine;
using UnityEngine.Events;

public class Alarm : MonoBehaviour
{
    [SerializeField] private UnityEvent _faced;
    [SerializeField] private UnityEvent _notFaced;

    public bool IsFaced { get; private set; }
    public bool IsNotFaced { get; private set; }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent<Thief>(out Thief thief))
        {
            _faced.Invoke();
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.TryGetComponent<Thief>(out Thief thief))
        {
            _notFaced.Invoke();
        }
    }
}