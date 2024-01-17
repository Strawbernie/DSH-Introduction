using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ComboManager : MonoBehaviour
{
    public TMP_Text text;
    private void Start()
    {
            ScoreManager.currentCombo = 0;
    }
    public void UpdateCombo()
    {
        if (ScoreManager.currentCombo > ScoreManager.highestCombo)
        {
            ScoreManager.highestCombo = ScoreManager.currentCombo;
        }
        ScoreManager.currentCombo = 0;
        text.text = ("");
    }
    public void ComboUP()
    {
        if (ScoreManager.currentCombo > 10)
        {
            text.text = "COMBO! " + ScoreManager.currentCombo;
        }
        else
        {
            text.text = ("");
        }
        if (ScoreManager.currentCombo > ScoreManager.highestCombo)
        {
            ScoreManager.highestCombo = ScoreManager.currentCombo;
        }
    }
}
