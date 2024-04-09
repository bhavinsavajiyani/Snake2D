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

    public LevelGrid(Vector2Int mgFoodPosRange, Vector2Int mbFoodPosRange)
    {
        _massGainerFoodPosRange = mgFoodPosRange;
        _massBurnerFoodPosRange = mbFoodPosRange;
    }

    public void Setup(Snake snake)
    {
        this._snake = snake;
        SpawnRandomFood();
    }

    private GameObject SpawnMassGainerFood()
    {
        _massGainerFoodPosition = new Vector2Int(
                Random.Range(2, _massGainerFoodPosRange.x),
                Random.Range(2, _massGainerFoodPosRange.y)
            );

        _massGainerFoodObject = new GameObject("MassGainer", typeof(SpriteRenderer));
        _massGainerFoodObject.GetComponent<SpriteRenderer>().sprite = GameAssets.Instance.massGainerFoodSprite;
        _massGainerFoodObject.GetComponent<SpriteRenderer>().sortingLayerName = "MassGainerFood";
        _massGainerFoodObject.transform.position = new Vector3(_massGainerFoodPosition.x, _massGainerFoodPosition.y, 0);

        _currentFoodObject = _massGainerFoodObject;
        return _currentFoodObject;
    }

    private GameObject SpawnMassBurnerFood()
    {
        _massBurnerFoodPosition = new Vector2Int(
                Random.Range(2, _massBurnerFoodPosRange.x),
                Random.Range(2, _massBurnerFoodPosRange.y)
            );

        _massBurnerFoodObject = new GameObject("MassBurner", typeof(SpriteRenderer));
        _massBurnerFoodObject.GetComponent<SpriteRenderer>().sprite = GameAssets.Instance.massBurnerFoodSprite;
        _massBurnerFoodObject.GetComponent<SpriteRenderer>().sortingLayerName = "MassBurnerFood";
        _massBurnerFoodObject.transform.position = new Vector3(_massBurnerFoodPosition.x, _massBurnerFoodPosition.y, 0);

        _currentFoodObject = _massBurnerFoodObject;
        return _currentFoodObject;
    }

    public void OnSnakeEatingMassGainerFood(Vector2Int snakePosition)
    {
        if(snakePosition ==  _massGainerFoodPosition)
        {
            Object.Destroy(_massGainerFoodObject);
            SpawnRandomFood();
        }
    }

    public void OnSnakeEatingMassBurnerFood(Vector2Int snakePosition)
    {
        if(snakePosition == _massBurnerFoodPosition)
        {
            Object.Destroy(_massBurnerFoodObject);
            SpawnRandomFood();
        }
    }

    private void SpawnRandomFood()
    {
        if(_currentFoodObject == null)
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
    }
}
