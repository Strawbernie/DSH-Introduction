using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public Canvas buttonCanvas;
    [SerializeField]
    private DialogueManager dialogueManager;
    public Animator animator;
    private void Awake()
    {
        buttonCanvas.gameObject.SetActive(false);
    }
    public void TriggerDialogue()
    {
        dialogueManager.StartDialogue(dialogue);
    }
    void OnTriggerEnter(Collider collider)
    {
        Debug.Log("It does work");
        buttonCanvas.gameObject.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        buttonCanvas.gameObject.SetActive(false);
    }
}

