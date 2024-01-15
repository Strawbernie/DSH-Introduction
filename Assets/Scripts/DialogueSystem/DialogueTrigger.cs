using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public Canvas buttonCanvas;
    private void Awake()
    {
        buttonCanvas.gameObject.SetActive(false);// made it so it can be tested without VR 
    }
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
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

