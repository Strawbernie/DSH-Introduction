using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public TMP_Text tutorialText;

    private Queue<string> tutorialSentences = new Queue<string>();

    public Canvas popUpCanvas;

    private void Awake()
    {
        popUpCanvas.gameObject.SetActive(false);
    }

    public void StartSequence(TutorialScreen tutorialScreen)
    {
        popUpCanvas.gameObject.SetActive(true);

        foreach (string tutorialSentence in tutorialScreen.tutorialScreens)
        {
            if(tutorialSentences != null)
            {
                tutorialSentences.Enqueue(tutorialSentence);
            }
        }
        NextScreen();

    }

    public void NextScreen()
    {
        if (tutorialSentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string tutorialScreen = tutorialSentences.Dequeue();
        tutorialText.text = tutorialScreen;
    }

    public void EndDialogue()
    {
        popUpCanvas.gameObject.SetActive(false);
    }
    /*[SerializeField]
    private PopUpManager popUpManager;
    [SerializeField]
    private PopUpSequence startSequence;

    private Queue<GameObject> screenSequence;
    private GameObject currentScreen;

    void Start()
    {
        StartSequence(startSequence);
    }

    public void StartSequence(PopUpSequence sequence)
    {
        screenSequence = new Queue<GameObject>();
        foreach (GameObject screen in sequence.screens)
        {
            screenSequence.Enqueue(screen);
        }

        NextScreen();
    }

    public void NextScreen()
    {
        if (screenSequence.Count == 0)
        {
            EndSequence(currentScreen);
            return;
        }

        if (currentScreen != null)
        {
            Destroy(currentScreen);
        }

        var screen = screenSequence.Dequeue();
        currentScreen = popUpManager.DisplayPopUp(screen);
    }

    private void EndSequence(GameObject screen)
    {
        Destroy(screen);
    }*/
}
