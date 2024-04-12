using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    private GameAssets _instance;
    public static GameAssets Instance;

    public Sprite snakeHeadSprite;
    public Sprite massGainerFoodSprite;
    public Sprite massBurnerFoodSprite;

    public AudioSounds[] soundsArray;

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
            Instance = _instance;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
    }

    [Serializable]
    public class AudioSounds
    {
        public SoundManager.SoundType soundType;
        public AudioClip soundClip;
    }
}
