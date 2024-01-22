using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartTutorialTrigger : TutorialTrigger
{
    [SerializeField]
    private Button nextSceneButton;
    public override void Start()
    {
        base.Start();
        nextSceneButton.gameObject.SetActive(false);
        Trigger();
    }
}
