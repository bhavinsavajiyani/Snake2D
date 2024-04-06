using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    private GameHandler _instance;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InitializeSnakeHead()
    {
        GameObject snakeGameObject = new GameObject("Snake");
        SpriteRenderer spriteRenderer = snakeGameObject.AddComponent<SpriteRenderer>();
        spriteRenderer.sortingLayerName = "Snake";
        spriteRenderer.sprite = GameAssets.Instance.snakeHeadSprite;
    }
}
