using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpSetUp : MonoBehaviour
{
    private Button button;
    public void SetUp(TutorialManager tutorialManager)
    { 
        button = GetComponentInChildren<Button>();
        button.onClick.AddListener(tutorialManager.NextScreen);
    }
}
