using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    
    private Queue<string> dialogueSentences;

    public Canvas canvas;

    public AudioManager audioManager;

    private void Awake()
    {
        canvas.gameObject.SetActive(false);
    }
    void Start()
    {
        dialogueSentences= new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        canvas.gameObject.SetActive(true);

        nameText.text = dialogue.name;

        audioManager.Play("CatVoice");

        foreach (string dialogueSentence in dialogue.dialogueSentences)
        {
            dialogueSentences.Enqueue(dialogueSentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (dialogueSentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string dialogueSentence = dialogueSentences.Dequeue();
        dialogueText.text = dialogueSentence;
    }

    public void EndDialogue()
    {
        canvas.gameObject.SetActive(false);
    }
}
