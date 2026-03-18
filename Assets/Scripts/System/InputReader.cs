using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public bool IsFlying { get; private set; }
    public bool IsShooting { get; private set; }

    public event Action Shooted;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightControl))
            Shooted?.Invoke();
    }

    private void FixedUpdate()
    {
        IsFlying = Input.GetKey(KeyCode.Space);
    }
}
