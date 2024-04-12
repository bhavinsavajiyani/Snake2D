using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoader
{
    public enum SceneName
    {
        Game,
        Loading,
        MainMenu
    }

    private static Action _loaderCallbackAction;

    public static void LoadScene(SceneName scene)
    {
        _loaderCallbackAction = () =>
        {
            SceneManager.LoadScene(scene.ToString());
        };

        SceneManager.LoadScene(SceneName.Loading.ToString());
    }

    public static void LoaderCallback()
    {
        if(_loaderCallbackAction != null)
        {
            _loaderCallbackAction();
            _loaderCallbackAction = null;
        }
    }
}
