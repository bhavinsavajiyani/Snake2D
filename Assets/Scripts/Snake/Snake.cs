using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private Vector2Int _gridPosition;
    private Vector2Int _gridMoveDirection;

    // Time remaining until next movement
    private float _moveTimer;
    
    // Amount of time between moves
    private float _moveDuration;
    private LevelGrid _levelGrid;

    public void Setup(LevelGrid levelGrid)
    {
        this._levelGrid = levelGrid;
    }

    // Start is called before the first frame update
    private void Awake()
    {
        _gridPosition = new Vector2Int(10, 10);
        _moveDuration = 0.5f;
        _moveTimer = _moveDuration;

        // By Default, the snake would move right.
        _gridMoveDirection = new Vector2Int(1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        InputHandling();
        Movement();
    }

    /// <summary>
    /// Check for Input, and set direction to move, as per input.
    /// </summary>
    private void InputHandling()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (_gridMoveDirection.y != -1)
            {
                _gridMoveDirection.x = 0;
                _gridMoveDirection.y = 1;
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (_gridMoveDirection.y != 1)
            {
                _gridMoveDirection.x = 0;
                _gridMoveDirection.y = -1;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (_gridMoveDirection.x != 1)
            {
                _gridMoveDirection.x = -1;
                _gridMoveDirection.y = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (_gridMoveDirection.x != -1)
            {
                _gridMoveDirection.x = 1;
                _gridMoveDirection.y = 0;
            }
        }
    }

    /// <summary>
    /// Move Snake as per input direction
    /// </summary>
    private void Movement()
    {
        _moveTimer += Time.deltaTime;
        if (_moveTimer >= _moveDuration)
        {
            _gridPosition += _gridMoveDirection;
            _moveTimer -= _moveDuration;
        }

        transform.position = new Vector3(_gridPosition.x, _gridPosition.y, 0);
        transform.eulerAngles = new Vector3(0, 0, GetFacingDirection(_gridMoveDirection) - 90.0f);

        _levelGrid.OnSnakeEatingMassGainerFood(_gridPosition);
        _levelGrid.OnSnakeEatingMassBurnerFood(_gridPosition);
    }

    private float GetFacingDirection(Vector2Int direction)
    {
        float result = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if(result < 0) result += 360;
        return result;
    }

    public Vector2Int GetGridPosition()
    {
        return _gridPosition;
    }
}
