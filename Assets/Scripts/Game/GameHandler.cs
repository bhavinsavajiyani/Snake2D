using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    private static GameHandler _instance;
    private static int _score;

    private LevelGrid _levelGrid;

    [SerializeField] private Snake _snake;

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }

        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _levelGrid = new LevelGrid(20, 20);
        _snake.Setup(_levelGrid);
        _levelGrid.Setup(_snake);
    }

    public static int GetScore()
    {
        return _score;
    }

    public static void AddScore(int scoreToAdd)
    {
        _score += scoreToAdd;
    }

    public static void DecreaseScore(int scoreToDecrease)
    {
        _score -= scoreToDecrease;

        if(_score < 0)
        {
            _score = 0;
        }
    }
}
