using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Alarm))]

public class CollisionDeteminant : MonoBehaviour
{
    [SerializeField] private UnityEvent _faced;
    [SerializeField] private UnityEvent _notFaced;

    private Alarm _alarm;

    private bool _isFaced;

    private void Awake()
    {
        _alarm = GetComponent<Alarm>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent<Thief>(out Thief thief))
        {
            _isFaced = true;
            _alarm.TurnOn(_isFaced);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.TryGetComponent<Thief>(out Thief thief))
        {
            _isFaced = false;
            _alarm.TurnOn(_isFaced);
        }
    }
}
