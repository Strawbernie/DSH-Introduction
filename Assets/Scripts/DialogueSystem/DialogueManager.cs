using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    
    private Queue<string> dialogueSentences;

    public Canvas dialogueCanvas;
    public DialogueTrigger dialogueTrigger;

    public AudioManager audioManager;
    public string clipName;

    [SerializeField]
    private NPCTrigger npcTrigger;

    private void Awake()
    {
        dialogueCanvas.gameObject.SetActive(false);
    }
    void Start()
    {
        dialogueSentences= new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Started Dialogue");
        dialogueCanvas.gameObject.SetActive(true);
        dialogueTrigger.buttonCanvas.gameObject.SetActive(false);

        nameText.text = dialogue.name;

        audioManager.Play(clipName);

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
        dialogueCanvas.gameObject.SetActive(false);
        dialogueTrigger.buttonCanvas.gameObject.SetActive(false);
        npcTrigger.dialogueHasEnded = true;
    }
}
