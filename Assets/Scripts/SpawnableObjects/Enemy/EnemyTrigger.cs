using System;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;

    public event Action<Enemy> Exited;

    private void OnEnable()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out PlayerBulletTrigger playerBulletTrigger))
            Exited?.Invoke(_enemy);
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out ScreenBorder screenBorder))
            Exited?.Invoke(_enemy);
    }
}
