using System;
using UnityEngine;

[RequireComponent(typeof(PlayerFlyer))]
[RequireComponent(typeof(PlayerRotator))]
[RequireComponent(typeof(ScoreCounter))]
[RequireComponent(typeof(PlayerTrigger))]
public class Player : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private PlayerBulletSpawner _bulletsSpawner;
    [SerializeField] private float _topOffset;
    
    private PlayerFlyer _flyer;
    private PlayerRotator _rotator;
    private PlayerTrigger _trigger;
    private ScoreCounter _scoreCounter;
    private Vector3 _startPosition;

    public event Action GameFinished;

    private void Awake()
    {
        _flyer = GetComponent<PlayerFlyer>();
        _rotator = GetComponent<PlayerRotator>();
        _trigger = GetComponent<PlayerTrigger>();
        _scoreCounter = GetComponent<ScoreCounter>();
        _startPosition = transform.position;
    }

    private void OnEnable()
    {
        _inputReader.Shooted += Shoot;

        _trigger.GroundDetected += Reset;

        _trigger.ScreenBorderEntered += _rotator.TurnOffRotation;
        _trigger.ScreenBorderExited += _rotator.TurnOnRotation;

        _trigger.BulletEntered += Reset;

        Initialize();
    }

    private void OnDisable()
    {
        _inputReader.Shooted -= Shoot;

        _trigger.GroundDetected -= Reset;

        _trigger.ScreenBorderEntered -= _rotator.TurnOffRotation;
        _trigger.ScreenBorderExited -= _rotator.TurnOnRotation;

        _trigger.BulletEntered -= Reset;
    }

    private void FixedUpdate()
    {
        if (_inputReader.IsFlying)
        {
            _flyer.Fly();
            _rotator.RotateUp();
        }

        _rotator.RotateDown();
    }

    private void Initialize()
    {
        _flyer.AssigneStartPosition(_startPosition);
        _scoreCounter.Reset();
    }

    private void Shoot()
    {
        _bulletsSpawner.GetFromPool(_bulletsSpawner.transform.position, transform);
    }

    private void Reset()
    {
        GameFinished?.Invoke();
    }
}