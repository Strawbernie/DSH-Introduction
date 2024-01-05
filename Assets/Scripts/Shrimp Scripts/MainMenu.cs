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
    public GameObject player;
    private void Awake()
    {
        if (startButton != null)
        {
            startButton.onClick.AddListener(StartGame);
        }
        if (sliceButton != null)
        {
            sliceButton.onClick.AddListener(ChairGame);
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
            sliceButton.onClick.RemoveListener(ChairGame);
        }

    }
    private void StartGame()
    {
        mainMenu.SetActive(false);
        LevelManager.Instance.LoadSceneAsync(startButtonSceneName);
    }
    public void ChairGame()
    {
        StatsManager.spawnLocation = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        StatsManager.Rotation = player.transform.rotation;
        mainMenu.SetActive(false);
        LevelManager.Instance.LoadSceneAsync("ChairRacing");
    }
    public void SliceGame()
    {
        StatsManager.spawnLocation = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        StatsManager.Rotation = player.transform.rotation;
        mainMenu.SetActive(false);
        LevelManager.Instance.LoadSceneAsync("BugSlicing");
    }
    public void CardGame()
    {
        StatsManager.spawnLocation = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        StatsManager.Rotation = player.transform.rotation;
        mainMenu.SetActive(false);
        LevelManager.Instance.LoadSceneAsync("CardBattling");
    }
}