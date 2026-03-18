using UnityEngine;

[RequireComponent(typeof(Restarter))]
public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private RestartWindow _restartWindow;
    
    private Restarter _restarter;

    private void Awake()
    {
        _restarter = GetComponent<Restarter>();
        _restartWindow.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _player.GameFinished += FinishGame;
    }

    private void OnDisable()
    {
        _player.GameFinished -= FinishGame;
        _restartWindow.Pushed -= StartGame;
    }

    private void FinishGame()
    {
        _restarter.FinishGameProcces(_player.transform, _restartWindow.transform);
        
        _player.GameFinished -= FinishGame;
        _restartWindow.Pushed += StartGame;
    }

    private void StartGame()
    {
        _restarter.StartGameProcces(_player.transform, _restartWindow.transform);

        _player.GameFinished += FinishGame;
        _restartWindow.Pushed -= StartGame;
    }
}
