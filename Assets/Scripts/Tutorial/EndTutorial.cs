using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Button))]

public class EndTutorial : MonoBehaviour
{
    private Button _loadSceneButton;
    private void Awake()
    {
        _loadSceneButton = GetComponent<Button>();
    }
    private void Start()
    {
        _loadSceneButton.onClick.AddListener(StartGame);
    }
    private void OnDestroy()
    {
        _loadSceneButton.onClick.RemoveListener(StartGame);
    }
    private void StartGame()
    {
        LevelManager.Instance.LoadSceneAsync("XRInteractionTookItDemo");
    }
}
