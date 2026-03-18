using UnityEngine;
using TMPro;
using System;

public class ScoreViewer : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private void OnEnable()
    {
        _text.text = Convert.ToString(0);
    }

    public void AssigneText(int score)
    {
        _text.text = Convert.ToString(score);
    }
}
