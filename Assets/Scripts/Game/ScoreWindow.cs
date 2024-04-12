using UnityEngine;
using UnityEngine.UI;

public class ScoreWindow : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _highScoreText;

    private void Awake()
    {
        _highScoreText.text = GetHighScore().ToString();
    }

    private void Update()
    {
        _scoreText.text = GameHandler.GetScore().ToString();
    }

    public static int GetHighScore()
    {
        return PlayerPrefs.GetInt("HighScore", 0);
    }

    public static bool TrySetNewHighScore(int newScore)
    {
        int highScore = GetHighScore();

        if(newScore > highScore)
        {
            PlayerPrefs.SetInt("HighScore", newScore);
            PlayerPrefs.Save();
            return true;
        }

        else
        {
            return false;
        }
    }
}
