using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerFlyer : MonoBehaviour
{
    [SerializeField] private float _tapForce;
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody;
    private float _startPositionY;

    public void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _startPositionY = transform.position.y;
    }

    public void Fly()
    {
        _rigidbody.velocity = new Vector2(_speed, _tapForce);
    }

    public void AssigneStartPosition(Vector3 startPosition)
    {
        transform.position = startPosition;
    }
}
