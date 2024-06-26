using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoaderCallback : MonoBehaviour
{
    private bool _firstUpdate = true;

    // Update is called once per frame
    void Update()
    {
        if (_firstUpdate)
        {
            _firstUpdate = false;
            SceneLoader.LoaderCallback();
        }
    }
}
