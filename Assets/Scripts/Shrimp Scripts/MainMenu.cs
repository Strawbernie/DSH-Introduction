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
        startButton.onClick.AddListener(StartGame);
        sliceButton.onClick.AddListener(SliceGame);
    }

    private void OnDestroy()
    {
        startButton.onClick.RemoveListener(StartGame);
        sliceButton.onClick.RemoveListener(SliceGame);
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