using System;
using UnityEngine;

public class Restarter : MonoBehaviour
{
    [SerializeField] private EnemiesSpawner _enemiesSpawner;
    [SerializeField] private Ground _ground;
    [SerializeField] private HUD _hud;

    public event Action GameFinished;
    public event Action Restarted;

    public void FinishGameProcces(Transform player, Transform restartWindow)
    {
        GameFinished?.Invoke();

        player.gameObject.SetActive(false);
        _hud.gameObject.SetActive(false);
        restartWindow.gameObject.SetActive(true);
        _ground.TurnAnimator();
    }

    public void StartGameProcces(Transform player, Transform restartWindow)
    {
        restartWindow.gameObject.SetActive(false);
        _hud.gameObject.SetActive(true);
        player.gameObject.SetActive(true);
        Restarted?.Invoke();
        _ground.TurnAnimator();
    }
}
