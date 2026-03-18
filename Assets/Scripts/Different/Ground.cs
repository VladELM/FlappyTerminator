using UnityEngine;

public class Ground : MonoBehaviour
{
    private Animator _animator;
    private bool _isAnimatorEnabled;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _isAnimatorEnabled = false;
    }

    public void TurnAnimator()
    {
        _animator.enabled = _isAnimatorEnabled;
        _isAnimatorEnabled = !_isAnimatorEnabled;
    }
}
