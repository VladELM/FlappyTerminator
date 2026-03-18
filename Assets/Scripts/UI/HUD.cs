using UnityEngine;

public class HUD : MonoBehaviour
{
    [SerializeField] private ScoreCounter _scoreCounter;

    private ScoreViewer _scoreViewer;

    private void OnEnable()
    {
        AssigneScoreViewer();
        _scoreCounter.ScoreIncreased += _scoreViewer.AssigneText;
    }

    private void OnDisable()
    {
        _scoreCounter.ScoreIncreased -= _scoreViewer.AssigneText;
    }

    private void AssigneScoreViewer()
    {
        int children = transform.childCount;

        for (int i = 0; i < children; i++)
        {
            if (transform.GetChild(i).TryGetComponent(out ScoreViewer scoreViewer))
            {
                _scoreViewer = scoreViewer;
                break;
            }
        }
    }
}
