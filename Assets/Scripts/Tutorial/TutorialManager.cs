using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [SerializeField]
    private PopUpManager popUpManager;
    [SerializeField]
    private PopUpSequence startSequence;

    private Queue<GameObject> screenSequence;
    private GameObject currentScreen;

    void Start()
    {
        StartSequence(startSequence);
    }

    private void StartSequence(PopUpSequence sequence)
    {
        screenSequence = new Queue<GameObject>();
        foreach (GameObject screen in sequence.screens)
        {
            screenSequence.Enqueue(screen);
        }

        NextScreen();
    }

    public void NextScreen() // get a Continue Button, to go to the next screen
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
    }
}
