using System.Collections;
using UnityEngine;

public abstract class BulletMover : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed;
    
    protected Coroutine _coroutine;

    public abstract void StartMoving(Transform directionTransform);

    public void StopMoving()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    protected IEnumerator Moving(Vector3 direction)
    {
        while (enabled)
        {
            yield return null;

            transform.position += direction * (_bulletSpeed * Time.deltaTime);
        }
    }
}
