using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartTutorialTrigger : TutorialTrigger
{
    [SerializeField]
    private Canvas nextSceneCanvas;
    public override void Start()
    {
        base.Start();
        nextSceneCanvas.gameObject.SetActive(false);
        Trigger();
    }
}
