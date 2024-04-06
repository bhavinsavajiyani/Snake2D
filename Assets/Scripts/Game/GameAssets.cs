using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    private GameAssets _instance;
    public static GameAssets Instance;

    public Sprite snakeHeadSprite;

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
            Instance = _instance;
        }

        else
        {
            Destroy(gameObject);
        }
    }
}
