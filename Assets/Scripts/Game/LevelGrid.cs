using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGrid
{
    private Vector2Int _massGainerFoodPosition;
    private Vector2Int _massGainerFoodPosRange;
    private GameObject _massGainerFoodObject;

    private Vector2Int _massBurnerFoodPosition;
    private Vector2Int _massBurnerFoodPosRange;
    private GameObject _massBurnerFoodObject;

    private Snake _snake;

    private GameObject _currentFoodObject;

    private int _width, _height;

    public LevelGrid(int width, int height)
    {
        this._width = width;
        this._height = height;

        _massGainerFoodPosRange = new Vector2Int(width, height);
        _massBurnerFoodPosRange = new Vector2Int(width, height);

        _massGainerFoodObject = Resources.Load("MassGainer") as GameObject;
        _massBurnerFoodObject = Resources.Load("MassBurner") as GameObject;
    }

    public void Setup(Snake snake)
    {
        this._snake = snake;
        SpawnMassGainerFood();
    }

    private GameObject SpawnMassGainerFood()
    {
        _massGainerFoodPosition = new Vector2Int(
                Random.Range(2, _massGainerFoodPosRange.x),
                Random.Range(2, _massGainerFoodPosRange.y)
            );

        _currentFoodObject = GameObject.Instantiate(_massGainerFoodObject, new Vector3(_massGainerFoodPosition.x, _massGainerFoodPosition.y, 0), Quaternion.identity);
        _currentFoodObject.name = "MassGainer";
        return _currentFoodObject;
    }

    private GameObject SpawnMassBurnerFood()
    {
        _massBurnerFoodPosition = new Vector2Int(
                Random.Range(2, _massBurnerFoodPosRange.x),
                Random.Range(2, _massBurnerFoodPosRange.y)
            );

        _currentFoodObject = GameObject.Instantiate(_massBurnerFoodObject, new Vector3(_massBurnerFoodPosition.x, _massBurnerFoodPosition.y, 0), Quaternion.identity);
        _currentFoodObject.name = "MassBurner";
        return _currentFoodObject;
    }

    public void SpawnRandomFood()
    {
        int rand = Random.Range(1, 11);
        Debug.Log("Rand: " + rand);

        if (rand < 5)
        {
            SpawnMassBurnerFood();
        }

        else
        {
            SpawnMassGainerFood();
        }
    }

    public Vector2Int ValidateGridPos(Vector2Int gridPos)
    {
        if(gridPos.x < 0)
        {
            gridPos.x = _width - 1;
        }

        if (gridPos.x > _width)
        {
            gridPos.x = 0;
        }

        if (gridPos.y < 0)
        {
            gridPos.y = _height - 1;
        }

        if(gridPos.y > _height)
        {
            gridPos.y = 0;
        }

        return gridPos;
    }
}
