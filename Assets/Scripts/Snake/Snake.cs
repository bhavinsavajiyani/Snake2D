using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private Vector2Int gridPosition;
    private Vector2Int gridMoveDirection;

    // Time remaining until next movement
    private float moveTimer;
    
    // Amount of time between moves
    private float moveDuration;

    // Start is called before the first frame update
    private void Awake()
    {
        gridPosition = new Vector2Int(10, 10);
        moveDuration = 0.5f;
        moveTimer = moveDuration;

        // By Default, the snake would move right.
        gridMoveDirection = new Vector2Int(1, 0);
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
            if (gridMoveDirection.y != -1)
            {
                gridMoveDirection.x = 0;
                gridMoveDirection.y = 1;
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (gridMoveDirection.y != 1)
            {
                gridMoveDirection.x = 0;
                gridMoveDirection.y = -1;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (gridMoveDirection.x != 1)
            {
                gridMoveDirection.x = -1;
                gridMoveDirection.y = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (gridMoveDirection.x != -1)
            {
                gridMoveDirection.x = 1;
                gridMoveDirection.y = 0;
            }
        }
    }

    /// <summary>
    /// Move Snake as per input direction
    /// </summary>
    private void Movement()
    {
        moveTimer += Time.deltaTime;
        if (moveTimer >= moveDuration)
        {
            gridPosition += gridMoveDirection;
            moveTimer -= moveDuration;
        }

        transform.position = new Vector3(gridPosition.x, gridPosition.y, 0);
        transform.eulerAngles = new Vector3(0, 0, GetFacingDirection(gridMoveDirection) - 90.0f);
    }

    private float GetFacingDirection(Vector2Int direction)
    {
        float result = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if(result < 0) result += 360;
        return result;
    }
}
