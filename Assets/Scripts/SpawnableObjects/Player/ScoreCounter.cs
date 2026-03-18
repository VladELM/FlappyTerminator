using System;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    private int _score;

    public event Action<int> ScoreIncreased;

    public void Reset()
    {
        _score = 0;
    }

    public void IncreaseScores()
    {
        _score++;
        ScoreIncreased?.Invoke(_score);
    }
}
