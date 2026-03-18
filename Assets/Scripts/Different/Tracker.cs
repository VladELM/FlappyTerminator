using UnityEngine;

public class Tracker : MonoBehaviour
{
    [SerializeField] protected Transform _target;
    [SerializeField] private float _offsetX;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 position = transform.position;
        position.x = _target.position.x + _offsetX;
        transform.position = position;
    }
}
