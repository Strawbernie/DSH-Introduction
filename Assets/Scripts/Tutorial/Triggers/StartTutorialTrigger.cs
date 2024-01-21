using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTutorialTrigger : TutorialTrigger
{
    public override void Start()
    {
        base.Start();
        Trigger();
    }
}
