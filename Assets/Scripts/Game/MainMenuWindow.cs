using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuWindow : MonoBehaviour
{
    private void Awake()
    {
        GameObject.Find("PlayButton").GetComponent<Button>().onClick.AddListener(() => {
            SceneLoader.LoadScene(SceneLoader.SceneName.Game);
        });

        GameObject.Find("QuitButton").GetComponent<Button>().onClick.AddListener(() => {
            Application.Quit();
        });

        GameObject.Find("HowToPlayButton").GetComponent<Button>().onClick.AddListener(() => {
            GameObject.Find("HowToPlayPanel").GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        });

        GameObject.Find("BackButton").GetComponent<Button>().onClick.AddListener(() => {
            GameObject.Find("HowToPlayPanel").GetComponent<RectTransform>().anchoredPosition = new Vector2(3000, 0);
        });
    }
}
