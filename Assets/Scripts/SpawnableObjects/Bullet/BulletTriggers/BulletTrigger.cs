using System;
using UnityEngine;

public class BulletTrigger<T> : MonoBehaviour where T : Target
{
    [SerializeField] private Transform _hitPlace;

    public event Action Exited;
    public event Action<Vector3> Hit;
    public event Action Defeated;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out T bulletTargetObject))
        {
            Defeated?.Invoke();
            Hit?.Invoke(_hitPlace.position);
            Exited?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out ScreenBorder screenBorder))
            Exited?.Invoke();
    }
}
