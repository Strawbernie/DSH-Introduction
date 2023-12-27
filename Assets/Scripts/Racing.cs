using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR;

public class Racing : MonoBehaviour
{
  public float movementSpeed;
    private InputDevice RightController;
    private InputDevice LeftController;
    public InputData inputData;
    float initialVelocity = 0f;
    float finalVelocity = 1f;
    float currentVelocity = 0f;
    float accelerationRate = .01f;
    float decelerationRate = .05f;
    void Start()
    {
        RightController = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
    }

    // Update is called once per frame
    void Update()
    {
        CheckControllerInput(RightController);
        CheckControllerInput(LeftController);
        currentVelocity = Mathf.Clamp(currentVelocity, initialVelocity, finalVelocity);
    }
    private void CheckControllerInput(InputDevice controller)
    {
        if (inputData._leftController.TryGetFeatureValue(CommonUsages.triggerButton, out bool LeftButton))
        {
            if (LeftButton)
            {
                currentVelocity = currentVelocity + (accelerationRate * Time.deltaTime);
                transform.Translate(0, 0, currentVelocity);
            }
        }
        else
        {
            currentVelocity = currentVelocity - (decelerationRate * Time.deltaTime);
            if (currentVelocity > 0)
            {
                transform.Translate(0, 0, currentVelocity);
            }
            else
            {
                transform.Translate(0, 0, 0);
            }
        }
        if (inputData._rightController.TryGetFeatureValue(CommonUsages.triggerButton, out bool RightButton))
        {
            if (RightButton)
            {
               
            }
        }
    }
}
