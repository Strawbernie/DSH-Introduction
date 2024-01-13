using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> dialogueSentences;
    void Start()
    {
        dialogueSentences= new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("starting dialogue with " + dialogue.name);

        dialogueSentences.Clear();

        foreach (string dialogueSentence in dialogue.dialogueSentences)
        {
            dialogueSentences.Enqueue(dialogueSentence);

            DisplayNextSentence();
        }
    }

    public void DisplayNextSentence()
    {
        if (dialogueSentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string dialogueSentence = dialogueSentences.Dequeue();
        Debug.Log(dialogueSentence);
    }

    public void EndDialogue()
    {
        Debug.Log("End of conversation");
    }
}
