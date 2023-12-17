using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public string startButtonSceneName;
    
    public Button startButton;
    public Button sliceButton;
    public GameObject mainMenu;
    private void Awake()
    {
        if (startButton != null)
        {
            startButton.onClick.AddListener(StartGame);
        }
        if (sliceButton != null)
        {
            sliceButton.onClick.AddListener(SliceGame);
        }

    }

    private void OnDestroy()
    {
        if (startButton != null)
        {
            startButton.onClick.RemoveListener(StartGame);
        }
        if (sliceButton != null)
        {
            sliceButton.onClick.RemoveListener(SliceGame);
        }

    }
    private void StartGame()
    {
        mainMenu.SetActive(false);
        LevelManager.Instance.LoadSceneAsync(startButtonSceneName);
    }
    private void SliceGame()
    {
        mainMenu.SetActive(false);
        LevelManager.Instance.LoadSceneAsync("BugSlicing");
    }
}