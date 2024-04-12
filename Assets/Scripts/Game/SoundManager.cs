using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public enum SoundType
    {
        SnakeMove,
        SnakeDie,
        SnakeEat,
        ButtonClick
    }

    private SoundManager _instance;
    public static SoundManager Instance;

    private AudioSource _audioSource;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            Instance = _instance;
            _audioSource = GetComponent<AudioSource>();
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySound(SoundType type)
    {
        _audioSource.PlayOneShot(GetAudioClip(type));
    }

    private static AudioClip GetAudioClip(SoundType type)
    {
        foreach(GameAssets.AudioSounds sound in GameAssets.Instance.soundsArray)
        {
            if(sound.soundType == type)
            {
                return sound.soundClip;
            }
        }

        return null;
    }
}
