using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private enum State
    {
        Alive,
        Dead
    }

    private Vector2Int _gridPosition;
    private Vector2Int _gridMoveDirection;

    // Time remaining until next movement
    private float _moveTimer;
    
    // Amount of time between moves
    private float _moveDuration;
    private LevelGrid _levelGrid;

    private int _snakeBodyCount = 0;
    private List<Vector2Int> _snakeMovementPosList = new List<Vector2Int>();
    private Stack<GameObject> _snakeBodyStack = new Stack<GameObject>();
    private GameObject _snakeBodyRef, _snakeBody;

    private State _state;

    public void Setup(LevelGrid levelGrid)
    {
        this._levelGrid = levelGrid;
    }

    // Start is called before the first frame update
    private void Awake()
    {
        _state = State.Alive;

        _gridPosition = new Vector2Int(10, 10);
        _moveDuration = 0.24f;
        _moveTimer = _moveDuration;

        // By Default, the snake would move right.
        _gridMoveDirection = new Vector2Int(1, 0);

        _snakeBodyRef = Resources.Load("SnakeBody") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        switch(_state)
        {
            case State.Alive:
                InputHandling();
                Movement();
                break;

            case State.Dead:
                break;
        }
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
            _moveTimer -= _moveDuration;
            _snakeMovementPosList.Insert(0, _gridPosition);
            _gridPosition += _gridMoveDirection;
            _gridPosition = _levelGrid.ValidateGridPos(_gridPosition);
        }

        transform.position = new Vector3(_gridPosition.x, _gridPosition.y, 0);
        transform.eulerAngles = new Vector3(0, 0, GetFacingDirection(_gridMoveDirection) - 90.0f);

        for (int i = 0; i < _snakeBodyStack.Count; i++)
        {
            Vector3 gridPos = new Vector3(_gridPosition.x, _gridPosition.y, 0);
            Vector3 _snakeBodyPos = new Vector3(_snakeMovementPosList[i].x, _snakeMovementPosList[i].y, 0);
            _snakeBodyStack.ElementAt(i).transform.position = _snakeBodyPos;
            _snakeBodyStack.ElementAt(i).transform.eulerAngles = new Vector3(0, 0, GetFacingDirection(_gridMoveDirection) - 90.0f);

            if(_snakeBodyStack.ElementAt(i).transform.position == gridPos)
            {
                Debug.Log("GameOver...");
                _state = State.Dead;
            }
        }
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

    private void CreateSnakeBody()
    {
        _snakeBody = Instantiate(_snakeBodyRef, new Vector3(GetGridPosition().x, GetGridPosition().y, 0), Quaternion.identity);
        _snakeBody.name = "SnakeBody";
        _snakeBody.transform.parent = transform;
        _snakeBody.GetComponent<SpriteRenderer>().sortingOrder = -_snakeBodyStack.Count;
        _snakeBodyStack.Push(_snakeBody);
    }

    private void DestroyBodyPart()
    {
        if(_snakeBodyStack.Count > 0)
        {
            GameObject item = _snakeBodyStack.Pop();
            Destroy(item);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("MassGainer"))
        {
            CreateSnakeBody();
            Destroy(collision.gameObject);
            _snakeBodyCount++;
            Debug.Log("SnakeBodyCount: " + _snakeBodyCount);
            _levelGrid.SpawnRandomFood();
            GameHandler.AddScore(Random.Range(10, 101));
        }

        if(collision.CompareTag("MassBurner"))
        {
            Destroy(collision.gameObject);

            _snakeBodyCount--;

            if(_snakeBodyCount < 0)
            {
                _snakeBodyCount = 0;
            }

            DestroyBodyPart();

            Debug.Log("SnakeBodyCount: " + _snakeBodyCount);
            _levelGrid.SpawnRandomFood();
            GameHandler.DecreaseScore(Random.Range(10, 60));
        }
    }
}
