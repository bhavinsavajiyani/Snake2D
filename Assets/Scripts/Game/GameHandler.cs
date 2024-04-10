using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    private GameHandler _instance;
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
}
