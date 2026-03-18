using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public event Action<Enemy> Restarted;

    public void Reset()
    {
        Restarted?.Invoke(this);
    }

    public void Initialize(Vector3 position)
    {
        transform.position = position;
    }
}
