using UnityEngine;

public class Sureface : MonoBehaviour
{
    [SerializeField] private Animation _animation;

    private void OnEnable()
    {
        _animation.enabled = true;
    }

    private void OnDisable()
    {
        _animation.enabled = false;
    }
}
