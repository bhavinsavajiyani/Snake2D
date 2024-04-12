using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseWindow : MonoBehaviour
{
    private static PauseWindow _instance;

    private void Awake()
    {
        _instance = this;

        GameObject.Find("PausePanel").GetComponent<RectTransform>().anchoredPosition = Vector2.zero;

        GameObject.Find("ResumeButton").GetComponent<Button>().onClick.AddListener(() => {
            SoundManager.Instance.PlaySound(SoundManager.SoundType.ButtonClick);
            GameHandler.ResumeGame();
        });

        GameObject.Find("MainMenuButton").GetComponent<Button>().onClick.AddListener(() => {
            SoundManager.Instance.PlaySound(SoundManager.SoundType.ButtonClick);
            SceneLoader.LoadScene(SceneLoader.SceneName.MainMenu);
        });

        Hide();
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    public static void ShowPauseWindow()
    {
        _instance.Show();
    }

    public static void HideWindow()
    {
        _instance.Hide();
    }
}
