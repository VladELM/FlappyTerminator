using System;
using UnityEngine;
using UnityEngine.UI;

public class RestartWindow : MonoBehaviour
{
    [SerializeField] private Button _restartButton;

    public event Action Pushed;

    private void OnEnable()
    {
        _restartButton.onClick.AddListener(NotifySubscribers);
    }

    private void OnDisable()
    {
        _restartButton.onClick.RemoveListener(NotifySubscribers);
    }

    private void NotifySubscribers()
    {
        Pushed?.Invoke();
    }
}
