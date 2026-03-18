using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerRotator : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _minRotationZ;
    [SerializeField] private float _maxRotationZ;

    private Rigidbody2D _rigidbody2D;
    private Quaternion _minRotation;
    private Quaternion _maxRotation;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _minRotation = Quaternion.Euler(0f, 0f, _minRotationZ);
        _maxRotation = Quaternion.Euler(0f, 0f, _maxRotationZ);
    }

    public void TurnOffRotation()
    {
        _rigidbody2D.freezeRotation = true;
    }

    public void TurnOnRotation()
    {
        _rigidbody2D.freezeRotation = false;
    }

    public void RotateUp()
    {
        transform.rotation = _maxRotation;
    }

    public void RotateDown()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
    }
}
