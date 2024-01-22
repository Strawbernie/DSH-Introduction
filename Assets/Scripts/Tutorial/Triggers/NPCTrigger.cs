using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCTrigger : TutorialTrigger
{

    [SerializeField]
    private DialogueManager dialogueManager;
    public bool dialogueHasEnded = false;
    [SerializeField]
    private float waitTime = 2f;
    [SerializeField]
    private Canvas nextSceneCanvas;

    public override void Start()
    {
        base.Start();
    }
    void Update()
    {
        if (active)
        {
            if (dialogueHasEnded == true)
            {
                nextSceneCanvas.gameObject.SetActive(true);
                StartCoroutine("DelayTrigger");
            }
        }
    }

    IEnumerator DelayTrigger()
    {
        yield return new WaitForSeconds(waitTime);
        Debug.Log("Waited for" + waitTime +  "sec then triggered");
        Trigger();
    }
}
