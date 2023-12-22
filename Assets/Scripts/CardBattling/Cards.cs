using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR;

public class Cards : MonoBehaviour
{
    private InputDevice RightController;
    private InputData inputData;
    public bool hasBeenPlayed;
    public int handIndex;
    private GameManager gm;
    void Start()
    {
        RightController = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
        inputData = FindObjectOfType<InputData>();
        gm = FindObjectOfType<GameManager>();
    }
    private void Update()
    {
        //CheckControllerInput(RightController);
    }
    /*private void CheckControllerInput(InputDevice controller)
    {
        if (inputData._rightController.TryGetFeatureValue(CommonUsages.triggerButton, out bool RightButton))
        {
            if (RightButton)
            {
                if(!hasBeenPlayed)
                {
                    transform.position += Vector3.up * 5;
                    hasBeenPlayed= true;
                    gm.availableCardSlots[handIndex] = true;
                    Invoke("MoveToDiscardPile",1f);
                }
            }
        }
    }
    */
    void MoveToDiscardPile()
    {
        gm.discardPile.Add(this);
        gameObject.SetActive(false);
    }
    public void PlayCard()
    {
        if (!hasBeenPlayed)
        {
            transform.position += Vector3.up * 5;
            hasBeenPlayed = true;
            gm.availableCardSlots[handIndex] = true;
            Invoke("MoveToDiscardPile", 1f);
        }
    }
}
