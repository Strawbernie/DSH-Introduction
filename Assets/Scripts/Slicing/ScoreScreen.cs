using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreScreen : MonoBehaviour
{
    public TextMeshProUGUI text;

    void Start()
    {
        text.text = "You sliced " + ScoreManager.Sliced + " Objects " + "You missed "+ScoreManager.Missed +" Bots" +"                Your highest combo was: "+ScoreManager.highestCombo;
    }

public void TryAgain()
    {
        SceneManager.LoadScene("BugSlicing");
    }
    public void GoBack()
    {
        SceneManager.LoadScene("XRInteractionTookitDemo");
    }
}
