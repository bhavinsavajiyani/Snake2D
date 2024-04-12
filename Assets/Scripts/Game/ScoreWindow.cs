using UnityEngine;
using UnityEngine.UI;

public class ScoreWindow : MonoBehaviour
{
    private Text _scoreText;

    private void Awake()
    {
        _scoreText = GetComponentInChildren<Text>();
    }

    private void Update()
    {
        _scoreText.text = "Score: " + GameHandler.GetScore();
    }
}
