using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsTrigger : TutorialTrigger
{

    [SerializeField]
    private float waitTime = 10f;
    [SerializeField]
    private Canvas tutorialCanvas;


    public override void Start()
    {
        base.Start();
    }
    void Update()
    {
        if (active)
        {
            if (tutorialCanvas.gameObject == active)
            {
                Debug.Log("Starting Coroutine!");
                StartCoroutine("DelayTrigger");
            }

        }
    }

    IEnumerator DelayTrigger()
    {
        yield return new WaitForSeconds(waitTime);
        Debug.Log("Waited for" + waitTime + "sec then triggered");
        Trigger();
    }
}
