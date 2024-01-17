using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class RacingScreen : MonoBehaviour
{
    public TextMeshProUGUI text;

    void Start()
    {
        if (ScoreManager.wonRacing)
        {
            text.text = "You Win";
        }
        else
        {
            text.text = "You Lost";
        }

    }

    public void TryAgain()
    {
        SceneManager.LoadScene("ChairRacing");
    }
    public void GoBack()
    {
        SceneManager.LoadScene("XRInteractionTookitDemo");
    }
}
