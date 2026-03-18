using System;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    public event Action GroundDetected;
    public event Action ScreenBorderEntered;
    public event Action ScreenBorderExited;
    public event Action BulletEntered;

    private void Start()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out ScreenBorder screenBorder))
            ScreenBorderEntered?.Invoke();
        else if (collider.TryGetComponent(out Ground ground))
            GroundDetected?.Invoke();
        else if (collider.TryGetComponent(out EnemyBulletTrigger enemyBulletTrigger))
            BulletEntered?.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out ScreenBorder screenBorder))
            ScreenBorderExited?.Invoke();
    }
}
