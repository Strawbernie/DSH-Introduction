using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTrigger : MonoBehaviour
{
    [SerializeField]
    private TutorialTrigger[] triggersToEnable;

    public TutorialManager tutorialManager;
    public PopUpSequence mySequence;
    public bool active = false;

    public virtual void Start()
    {
        tutorialManager = FindObjectOfType<TutorialManager>();
    }

    public void Trigger()
    {
        if (active)
        {
            tutorialManager.StartSequence(mySequence);
            EnableTriggers();
            active = false;
        }
    }

    public virtual void EnableTriggers()
    {
        foreach (TutorialTrigger trigger in triggersToEnable)
        {
            trigger.active = true;
        }
    }
}
